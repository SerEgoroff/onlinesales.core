﻿// <copyright file="File.cs" company="WavePoint Co. Ltd.">
// Licensed under the MIT license. See LICENSE file in the samples root for full license information.
// </copyright>

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SalesPro.DataAnnotations;

namespace SalesPro.Entities
{
    [Table("file")]
    public class File : BaseEntity
    {
        [Required]
        [Searchable]
        public string ScopeUid { get; set; } = string.Empty;

        [Searchable]
        public string Name { get; set; } = string.Empty;

        public long Size { get; set; } = 0;

        public string Extension { get; set; } = string.Empty;

        public string MimeType { get; set; } = string.Empty;

        public byte[] Data { get; set; } = Array.Empty<byte>();
    }
}