global using MoneyBuilder.Services;
global using MoneyBuilder.Repository;
global using MoneyBuilder.APIs.Errors;
global using MoneyBuilder.APIs.Helpers;
global using MoneyBuilder.Core.Entities;
global using MoneyBuilder.APIs.Extensions;
global using MoneyBuilder.APIs.MiddleWares;
global using MoneyBuilder.APIs.Dtos.LevelDtos;
global using MoneyBuilder.APIs.Dtos.LectureDto;
global using MoneyBuilder.APIs.Dtos.AccountDtos;
global using MoneyBuilder.Core.Services.Contract;
global using MoneyBuilder.Core.Entities.Identity;
global using MoneyBuilder.Core.Repositories.Contract;
global using MoneyBuilder.Repository.Data.Configurations;
global using MoneyBuilder.Core.Specifications.LevelSpecs;
global using MoneyBuilder.Core.Specifications.LectureSpecs;

global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Authentication.JwtBearer;

global using System.Net;
global using System.Text;
global using System.Net.Mail;
global using System.Text.Json;
global using System.Security.Claims;
global using System.ComponentModel.DataAnnotations;

global using Serilog;
global using AutoMapper;





