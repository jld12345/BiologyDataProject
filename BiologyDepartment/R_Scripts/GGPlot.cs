using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiologyDepartment.R_Scripts
{
    class GGPlot
    {
        public enum GGPlot2
        {
            [ToolTip("geom_abline(geom_hline, geom_vline):  Lines: horizontal, vertical, and specified by slope and intercept.")]
            geom_abline,
            [ToolTip("geom_bar(stat_count):  Bars, rectangles with bases on x-axis:")]
            geom_bar,
            [ToolTip("geom_bin2d(stat_bin2d, stat_bin_2d):  Add heatmap of 2d bin counts.")]
            geom_bin2d,
            [ToolTip("geom_blank:  Blank, draws nothing.")]
            geom_blank,
            [ToolTip("geom_boxplot(stat_boxplot):  Box and whiskers plot.")]
            geom_boxplot,
            [ToolTip("geom_contour(stat_contour):  Display contours of a 3d surface in 2d.")]
            geom_contour,
            [ToolTip("geom_count(stat_sum):  Count the number of observations at each location.")]
            geom_count,
            [ToolTip("geom_crossbar(geom_errorbar, geom_linerange, geom_pointrange):  Vertical intervals: lines, crossbars & errorbars.")]
            geom_crossbar,
            [ToolTip("geom_density(stat_density):  Display a smooth density estimate.")]
            geom_density,
            [ToolTip("geom_density_2d(geom_density2d, stat_density2d, stat_density_2d):  Contours from a 2d density estimate.")]
            geom_density2d,
            [ToolTip("geom_dotplot:  Dot plot")]
            geom_dotplot,
            [ToolTip("geom_errorbarh:  Horizontal error bars")]
            geom_errorbarh,
            [ToolTip("geom_freqpoly(geom_histogram, stat_bin):  Histograms and frequency polygons.")]
            geom_freqpoly,
            [ToolTip("geom_hex(stat_bin_hex, stat_binhex):  Hexagon binning.")]
            geom_hex,
            [ToolTip("geom_jitter:  Points, jittered to reduce overplotting.")]
            geom_jitter,
            [ToolTip("geom_label(geom_text):  Textual annotations.")]
            geom_label,
            [ToolTip("geom_map:  Polygons from a reference map.")]
            geom_map,
            [ToolTip("geom_path(geom_line, geom_step):  Connect observations.")]
            geom_path,
            [ToolTip("geom_point:  Points, as for a scatterplot")]
            geom_point,
            [ToolTip("geom_polygon:  Polygon, a filled path.")]
            geom_polygon,
            [ToolTip("geom_quantile(stat_quantile):  Add quantile lines from a quantile regression.")]
            geom_quantile,
            [ToolTip("geom_raster(geom_rect, geom_tile):  Draw rectangles.")]
            geom_raster,
            [ToolTip("geom_ribbon(geom_area):  Ribbons and area plots.")]
            geom_ribbon,
            [ToolTip("geom_rug:  Marginal rug plots.")]
            geom_rug,
            [ToolTip("geom_segment(geom_curve):  Line segments and curves.")]
            geom_segment,
            [ToolTip("geom_smooth(stat_smooth):  Add a smoothed conditional mean.")]
            geom_smooth,
            [ToolTip("geom_violin(stat_ydensity):  Violin plot.")]
            geom_violin
        }

        public enum Statistics
        {
            [ToolTip("stat_ecdf:  Empirical Cumulative Density Function")]
            stat_ecdf,
            [ToolTip("stat_ellipse:  Plot data ellipses.")]
            stat_ellipse,
            [ToolTip("stat_function:  Superimpose a function.")]
            stat_function,
            [ToolTip("stat_identity:  Identity statistic.")]
            stat_identity,
            [ToolTip("stat_qq(geom_qq):  Calculation for quantile-quantile plot.")]
            stat_qq,
            [ToolTip("stat_summary_2d(stat_summary2d, stat_summary_hex):  Bin and summarise in 2d (rectangle & hexagons)")]
            stat_summary_2d,
            [ToolTip("stat_unique:  Remove duplicates.")]
            stat_unique
        }

        public enum Scales
        {
            [ToolTip("expand_limits: Expand the plot limits with data.")]
            expand_limits,
            [ToolTip("guides: Set guides for each scale.")]
            guides,
            [ToolTip("guide_legend:  Legend guide.")]
            guide_legend,
            [ToolTip("guide_colourbar(guide_colorbar):  Continuous colour bar guide.")]
            guide_colourbar,
            [ToolTip("lims(xlim, ylim):  Convenience functions to set the axis limits.")]
            lims,
            [ToolTip("scale_alpha(scale_alpha_continuous, scale_alpha_discrete):  Alpha scales.")]
            scale_alpha,
            [ToolTip("scale_colour_brewer(scale_color_brewer, scale_color_distiller, scale_colour_distiller, scale_fill_brewer, scale_fill_distiller):  Sequential, diverging and qualitative colour scales from colorbrewer.org")]
            scale_colour_brewer,
            [ToolTip("scale_colour_gradient(scale_color_continuous, scale_color_gradient, scale_color_gradient2, scale_color_gradientn, scale_colour_continuous, scale_colour_date, scale_colour_datetime, scale_colour_gradient2, scale_colour_gradientn, scale_fill_continuous, scale_fill_date, scale_fill_datetime, scale_fill_gradient, scale_fill_gradient2, scale_fill_gradientn):  Smooth gradient between two colours")]
            scale_colour_gradient,
            [ToolTip("scale_colour_grey(scale_color_grey, scale_fill_grey):  Sequential grey colour scale.")]
            scale_colour_grey,
            [ToolTip("scale_colour_hue(scale_color_discrete, scale_color_hue, scale_colour_discrete, scale_fill_discrete, scale_fill_hue):  Qualitative colour scale with evenly spaced hues.")]
            scale_color_hue,
            [ToolTip("scale_identity(scale_alpha_identity, scale_color_identity, scale_colour_identity, scale_fill_identity, scale_linetype_identity, scale_shape_identity, scale_size_identity):  Use values without scaling.")]
            scale_identity,
            [ToolTip("scale_manual(scale_alpha_manual, scale_color_manual, scale_colour_manual, scale_fill_manual, scale_linetype_manual, scale_shape_manual, scale_size_manual):  Create your own discrete scale.")]
            scale_manual,
            [ToolTip("scale_linetype(scale_linetype_continuous, scale_linetype_discrete):  Scale for line patterns.")]
            scale_linetype,
            [ToolTip("scale_shape(scale_shape_continuous, scale_shape_discrete):  Scale for shapes, aka glyphs.")]
            scale_shape,
            [ToolTip("scale_size(scale_radius, scale_size_area, scale_size_continuous, scale_size_date, scale_size_datetime, scale_size_discrete):  Scale size(area or radius).")]
            scale_size,
            [ToolTip("scale_x_discrete(scale_y_discrete):  Discrete position.")]
            scale_x_discrete,
            [ToolTip("labs(ggtitle, xlab, ylab):  Change axis labels and legend titles")]
            labs,
            [ToolTip("update_labels:  Update axis/legend labels")]
            update_labels
        }

        string MainTitle { get; set; }
        string YAxisLabel { get; set; }
        string XAxisLabel { get; set; }
        string XVariable { get; set; }
        string YVariable { get; set; }
        string Color { get; set; }
        string Fill { get; set; }
        string LegendTitle { get; set; }
    }
}
