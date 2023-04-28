﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ToDoTaskSolution.Entities;

[Table("ASSIGNMENTS")]
public partial class Assignment
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Required]
    [Column("CREATED_BY")]
    [StringLength(50)]
    [Unicode(false)]
    public string CreatedBy { get; set; }

    [Required]
    [Column("ASSIGNED_TO")]
    [StringLength(50)]
    [Unicode(false)]
    public string AssignedTo { get; set; }

    [InverseProperty("Assignment")]
    public virtual ICollection<Todotask> Todotasks { get; set; } = new List<Todotask>();
}