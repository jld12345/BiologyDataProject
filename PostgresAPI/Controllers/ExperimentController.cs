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
            Experiment experiment = dao.BulkExportJSON(id);
            if (experiment == null)
            {
                return NotFound();
            }

            return Ok(JObject.Parse(experiment.JSONB));
        }
    }
}
