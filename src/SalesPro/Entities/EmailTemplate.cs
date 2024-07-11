﻿// <copyright file="EmailTemplate.cs" company="WavePoint Co. Ltd.">
// Licensed under the MIT license. See LICENSE file in the samples root for full license information.
// </copyright>

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using OnlineSales.DataAnnotations;

namespace OnlineSales.Entities
{
    [Table("email_template")]
    [SupportsChangeLog]
    public class EmailTemplate : BaseEntity
    {
        [Required]
        [Searchable]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Searchable]
        public string Subject { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the HTML template body of the email.
        /// </summary>
        [Required]
        [Searchable]
        public string BodyTemplate { get; set; } = string.Empty;

        [Required]
        [Searchable]
        public string FromEmail { get; set; } = string.Empty;

        [Required]
        [Searchable]
        public string FromName { get; set; } = string.Empty;

        [Required]
        public int EmailGroupId { get; set; }

        [JsonIgnore]
        [ForeignKey("EmailGroupId")]
        public virtual EmailGroup? EmailGroup { get; set; }

        [Required]
        [Searchable]
        public string Language { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets how many times an email should resend once sending failed.
        /// </summary>
        public int RetryCount { get; set; }

        /// <summary>
        /// Gets or sets the frequency in minutes where an email should resend after a failed attempt.
        /// </summary>
        public int RetryInterval { get; set; }
    }
}