﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Unosquare.Labs.EmbedIO.Modules;

namespace Unosquare.Labs.EmbedIO.Tests.TestObjects
{
    public class TestRegexController : WebApiController
    {
        public const string RelativePath = "api/";

        [WebApiHandler(HttpVerbs.Get, "/" + RelativePath + "regex/{id}")]
        public bool GetPerson(WebServer server, HttpListenerContext context, int id)
        {
            try
            {
                if (PeopleRepository.Database.Any(p => p.Key == id))
                {
                    return context.JsonResponse(PeopleRepository.Database.FirstOrDefault(p => p.Key == id));
                }

                throw new KeyNotFoundException("Key Not Found: " + id);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                return context.JsonResponse(ex);
            }
        }

        [WebApiHandler(HttpVerbs.Get, "/" + RelativePath + "regexdate/{date}")]
        public bool GetPerson(WebServer server, HttpListenerContext context, DateTime date)
        {
            try
            {
                if (PeopleRepository.Database.Any(p => p.DoB == date))
                {
                    return context.JsonResponse(PeopleRepository.Database.FirstOrDefault(p => p.DoB == date));
                }

                throw new KeyNotFoundException("Key Not Found: " + date);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                return context.JsonResponse(ex);
            }
        }


        [WebApiHandler(HttpVerbs.Get, "/" + RelativePath + "regextwo/{skill}/{age}")]
        public bool GetPerson(WebServer server, HttpListenerContext context, string skill, int age)
        {
            try
            {
                if (PeopleRepository.Database.Any(p => p.MainSkill.ToLower() == skill.ToLower() && p.Age == age))
                {
                    return context.JsonResponse(PeopleRepository.Database.FirstOrDefault(p => p.MainSkill.ToLower() == skill.ToLower() && p.Age == age));
                }

                throw new KeyNotFoundException("Key Not Found: " + skill + "-" + age);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return context.JsonResponse(ex);
            }
        }
    }
}