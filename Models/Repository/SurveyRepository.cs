﻿using Microsoft.EntityFrameworkCore;
using Survey.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Models.Repository
{
    public class SurveyRepository : ISurveyRepository
    {
        private ApplicationDbContext context;
        public SurveyRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Survey> CreateAsync(Survey entity)
        {
            this.context.Survey.Add(entity);
            await this.context.SaveChangesAsync();
            return entity;
        }

        public void Delete(Survey entity)
        {
            Survey trackedEntity = this.context.Survey.Find(entity.Id);

            if (trackedEntity != null)
            {
                this.context.Survey.Remove(trackedEntity);
                this.context.SaveChangesAsync();
            }
        }

        public IList<Survey> ReadAll()
        {
            return this.context.Survey.ToList();
        }

        public async Task<Survey> ReadById(int? id)
        {
            return await context.Survey.Include(o=>o.Company).FirstOrDefaultAsync(m => m.Id == id);
        }

        public Survey ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Survey>> RealAllIncludeCompany()
        {
            // return await context.Survey.Include(a => a.Company).ToListAsync();
            var surveys = context.Survey.Include(a => a.Company);
            return await surveys.ToListAsync();
        }

        public async Task<Survey> UpdateAsync(Survey entity)
        {
            Survey trackedEntity = this.context.Survey.Find(entity.Id);

            trackedEntity.Questions = entity.Questions;
            trackedEntity.QuestionsCount = entity.QuestionsCount;
            trackedEntity.status = Status.Completed;

            //if (entity.Id != 0 && string.IsNullOrEmpty(entity.CompanyName))
            //{
            //    trackedEntity.CompanyId = entity.CompanyId;
            //    trackedEntity.CompanyName = entity.CompanyName;
            //}
            await this.context.SaveChangesAsync();
            return trackedEntity;
        }

        public Survey Create(Survey entity)
        {
            throw new NotImplementedException();
        }
        private bool SurveyExists(int id)
        {
            return context.Survey.Any(e => e.Id == id);
        }

        bool ISurveyRepository.SurveyExists(int id)
        {
            throw new NotImplementedException();
        }

        public Survey Update(Survey entity)
        {
            throw new NotImplementedException();
        }

        public Company GetCompany(int id, string name)
        {
            var x = context.Companies;
            return context.Companies.Where(o=>o.Id == id && o.Name == name).FirstOrDefault();
        }

        public List<QuestionTypes> GetQuestionTypes()
        {
            return context.QuestionTypes.ToList();
        }
    }
}
