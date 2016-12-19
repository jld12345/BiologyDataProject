using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using PostgresAPI.Models;
using PostgresAPI.DataAccessObject;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PostgresAPI.Controllers
{
    public class ExperimentController : ApiController
    {
        DataDAO dao = new DataDAO();

        public IEnumerable<Experiment> GetAllExperiments()
        {
            return null;
        }

        public IHttpActionResult GetExperiment(int id)
        {
            Experiment experiment = dao.BulkExportData(id);
            if (experiment == null)
            {
                return NotFound();
            }
            experiment.SerializeDataToJSON();
            return Ok(JObject.Parse(experiment.JSONTableSerialized));
        }

        public IHttpActionResult GetExperiment([FromUri]string sUser, [FromUri]int id)
        {
            Experiment experiment = dao.BulkExportData(id);
            if (experiment == null)
            {
                return NotFound();
            }
            experiment.SerializeDataToJSON();
            return Ok(JObject.Parse(experiment.JSONTableSerialized));
        }
    }
}
