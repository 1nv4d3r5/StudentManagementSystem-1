﻿using System;

using Domain;

using StructureMap;

namespace TestView
{
    public class MainPage
    {
        private static void Main(string[] args)
        {
           DependencyInjector.ConfigureDependencies();

            var studentManagementSystem = ObjectFactory.GetInstance<StudentManagementSystem>();
            studentManagementSystem.Index();
        }
    }
}