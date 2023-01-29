﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Data;
using GrandCircusReferralsAPI.Models;
using GrandCircusReferralsAPI.HelperClasses;

namespace GrandCircusReferralsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public async Task<List<BaseUser>> Get()
        {
            var users = new List<BaseUser>();

            using (IDbConnection database = new System.Data.SqlClient.SqlConnection(DatabaseConnectionHelper.GetDatabaseConnection()))
            {
                users = database.Query<BaseUser>("dbo.sp_GetAllCandidateBaseInfo").ToList();
            }

            return users;
        }

        [HttpGet]
        [Route("/api/GetNotesByCandidateID")]
        public async Task<List<BaseNote>> Get(int candidateID)
        {
            var notes = new List<BaseNote>();

            using (IDbConnection database = new System.Data.SqlClient.SqlConnection(DatabaseConnectionHelper.GetDatabaseConnection()))
            {
                notes = database.Query<BaseNote>($"dbo.sp_GetNotesByCandidateID {candidateID}").ToList();
            }

            return notes;
        }

        [HttpDelete]
        [Route("/api/DeleteNoteByNoteID")]
        public async Task Delete(int noteID)
        {
            using (IDbConnection database = new System.Data.SqlClient.SqlConnection(DatabaseConnectionHelper.GetDatabaseConnection()))
            {
                database.Execute($"dbo.sp_DeleteNoteByNoteID {noteID}");
            }
        }

        [HttpPost]
        [Route("/api/AddNewUser")]
        public async Task Post(AddNewUserModel newUser)
        {
            using (IDbConnection database = new System.Data.SqlClient.SqlConnection(DatabaseConnectionHelper.GetDatabaseConnection()))
            {
                database.Execute("dbo.sp_AddNewUser", newUser, commandType: CommandType.StoredProcedure);
            }
        }
    }
}