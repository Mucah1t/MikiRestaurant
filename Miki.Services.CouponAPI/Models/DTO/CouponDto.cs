﻿using System.ComponentModel.DataAnnotations;

namespace Miki.Services.CouponAPI.Models.DTO
{
    public class CouponDto
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public double DiscountAmount { get; set; }
    }
}