﻿using System;
using MathSite.Common.Entities;

namespace MathSite.Entities
{
    /// <summary>
    /// </summary>
    public class PostRating : Entity
    {
        /// <summary>
        /// </summary>
        public bool? Value { get; set; }

        /// <summary>
        /// </summary>
        public bool Allowed { get; set; }

        /// <summary>
        /// </summary>
        public Guid PostId { get; set; }

        /// <summary>
        /// </summary>
        public Post Post { get; set; }

        /// <summary>
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// </summary>
        public User User { get; set; }
    }
}