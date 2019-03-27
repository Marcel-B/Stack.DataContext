﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using com.b_velop.stack.DataContext.Abstract;
using com.b_velop.stack.DataContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace com.b_velop.stack.DataContext.Repository
{
    public class MeasurePointRepository : IDataStore<MeasurePoint>
    {
        private readonly ILogger<MeasurePointRepository> _logger;
        private readonly MeasureContext _context;

        public MeasurePointRepository(
            MeasureContext context,
            ILogger<MeasurePointRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<MeasurePoint> SaveAsync(
            MeasurePoint value)
        {
            try
            {
                var result = await _context.MeasurePoints.AddAsync(value);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(2832, ex, $"Error occurred while inserting '{value}'", value);
                return null;
            }
        }

        public async Task<MeasurePoint> UpdateAsync(
            Guid id,
            MeasurePoint value)
        {
            try
            {
                var tmp = await _context.MeasurePoints.FirstOrDefaultAsync(x => x.Id == id);
                _context.Entry(tmp).State = EntityState.Modified;
                tmp.Display = value.Display;
                tmp.Location = value.Location;
                tmp.Max = value.Max;
                tmp.Min = value.Min;
                tmp.Unit = value.Unit;
                tmp.ExternId = value.ExternId;
                await _context.SaveChangesAsync();
                return tmp;
            }
            catch (Exception ex)
            {
                _logger.LogError(2834, ex, $"Error occurred while updating '{id}'", id, value);
                return null;
            }
        }

        public async Task<MeasurePoint> DeleteAsync(
            MeasurePoint value)
            => await DeleteAsync(value.Id);

        public async Task<MeasurePoint> DeleteAsync(
            Guid id)
        {
            try
            {
                var tmp = await _context.MeasurePoints.FirstOrDefaultAsync(x => x.Id == id);
                _context.MeasurePoints.Remove(tmp);
                await _context.SaveChangesAsync();
                return tmp;
            }
            catch (Exception ex)
            {
                _logger.LogError(2833, ex, $"Error occurred while deleting '{id}'.", id);
                return null;
            }
        }

        public async Task<IEnumerable<MeasurePoint>> GetAllAsync()
            => await _context.MeasurePoints.ToListAsync();

        public async Task<int> SaveBulkAsync(
            MeasurePoint[] values)
        {
            try
            {
                await _context.MeasurePoints.AddRangeAsync(values);
                var result = await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger. LogError(2835, ex, $"Error occurred while inserting bulk.", values);
                return -1;
            }
        }

        public async Task<MeasurePoint> GetAsync(Guid id)
        {
            try
            {
                var current = await _context.MeasurePoints.FirstOrDefaultAsync(x => x.Id == id);
                return current;
            }
            catch (Exception ex)
            {
                _logger.LogError(2831, ex, $"Error occurred while getting '{id}'.", id);
                return null;
            }
        }
    }
}