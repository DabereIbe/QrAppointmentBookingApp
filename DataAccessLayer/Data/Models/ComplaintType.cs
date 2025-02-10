using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Data.Models;

public class ComplaintType
{
    [Key]
    public string Id { get; set; }

    public string Name { get; set; }
}
