﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VetTrainer.Models;


namespace VetTrainer.Views.ViewModel
{
    public class UsersViewModel
    {
        public IList<User> users = new List<User>();
    }
}