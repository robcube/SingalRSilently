using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using d3poll.Models;

namespace d3poll.Controllers
{
    public class ReportLogsController : ApiController
    {
        private ReportLogModel db = new ReportLogModel();

        // GET: api/ReportLogs
        public IQueryable<ReportLog> GetReportLogs()
        {
            return db.ReportLogs.OrderByDescending(x => x.Stamp);
        }

        // GET: api/ReportLogs/5
        [ResponseType(typeof(ReportLog))]
        public async Task<IHttpActionResult> GetReportLog(int id)
        {
            ReportLog reportLog = await db.ReportLogs.FindAsync(id);
            if (reportLog == null)
            {
                return NotFound();
            }

            return Ok(reportLog);
        }

        // PUT: api/ReportLogs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutReportLog(int id, ReportLog reportLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reportLog.Id)
            {
                return BadRequest();
            }

            db.Entry(reportLog).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportLogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ReportLogs
        [ResponseType(typeof(ReportLog))]
        public async Task<IHttpActionResult> PostReportLog(ReportLog reportLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ReportLogs.Add(reportLog);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = reportLog.Id }, reportLog);
        }

        // DELETE: api/ReportLogs/5
        [ResponseType(typeof(ReportLog))]
        public async Task<IHttpActionResult> DeleteReportLog(int id)
        {
            ReportLog reportLog = await db.ReportLogs.FindAsync(id);
            if (reportLog == null)
            {
                return NotFound();
            }

            db.ReportLogs.Remove(reportLog);
            await db.SaveChangesAsync();

            return Ok(reportLog);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReportLogExists(int id)
        {
            return db.ReportLogs.Count(e => e.Id == id) > 0;
        }
    }
}