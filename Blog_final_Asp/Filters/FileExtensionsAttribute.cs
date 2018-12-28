using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog_final_Asp.Filters
{
    /// <summary>
    /// Filtre d'extension de fichier, tiré de -> https://stackoverflow.com/a/37638328/10351751
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FileExtensionsAttribute : ValidationAttribute
    {
        private List<string> AllowedExtensions { get; set; }

        public FileExtensionsAttribute(string fileExtensions)
        {
            AllowedExtensions = fileExtensions.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public override bool IsValid(object value)
        {

            if (value is HttpPostedFileBase file)
            {
                var fileName = file.FileName;

                return AllowedExtensions.Any(y => fileName.EndsWith(y));
            }

            return true;
        }
    }
}