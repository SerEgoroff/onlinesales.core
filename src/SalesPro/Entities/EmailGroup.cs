﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using SalesPro.DataAnnotations;

namespace SalesPro.Entities
{
    [Table("email_group")]
    [SupportsChangeLog]
    public class EmailGroup : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name of the email group.
        /// </summary>
        [Required]
        [Searchable]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Searchable]
        public string Language { get; set; } = string.Empty;

        [JsonIgnore]
        public virtual ICollection<EmailTemplate>? EmailTemplates { get; set; }
    }
}