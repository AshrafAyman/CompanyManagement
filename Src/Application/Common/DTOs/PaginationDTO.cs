﻿using System.ComponentModel.DataAnnotations;

namespace Application.Common.DTOs;

public class PaginationDTO
{
    private int _pagesize;
    private int _currentpage;

    [Required]
    public int Page_size { get => _pagesize; set => _pagesize = value; }

    [Required]
    public int Current_page { get => _currentpage; set => _currentpage = value; }
}