﻿namespace RashaPrimeWeb.Domain.Entities
{
    public class TagToNews
    {


        public int TagId { get; set; }
        public int NewsId { get; set; }

        public Tag Tag { get; set; }
        public News News { get; set; }

    }
}
