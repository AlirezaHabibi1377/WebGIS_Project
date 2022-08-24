using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data;

namespace WebGISMVC.Models
{
    public class Layer
    {
        [Display(Name = "LayerName")]
        public string uname { get; set; }
        public string psw { get; set; }
        public string Name { set; get; }
        [Required]
        public LayerType Type { set; get; }
        [Required]
        public string Source { set; get; }
        public string URL { set; get; }
        public string Title { set; get; }
        public bool visible { set; get; }
        public string Format { set; get; }
        
        [Required]
        public bool IsBaseMap { set; get; }
        
        public string search { set; get; }

        public DataTable fd;
    }
    public enum LayerType
    {
        Raster,
        RasterTile,
        Vector
    }
}