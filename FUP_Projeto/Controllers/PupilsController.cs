﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FUP_Projeto.Data;
using FUP_Projeto.Models;

namespace FUP_Projeto.Controllers
{
    public class PupilsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PupilsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pupils
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aluno.ToListAsync());
        }

        // GET: Pupils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pupil = await _context.Aluno
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pupil == null)
            {
                return NotFound();
            }

            return View(pupil);
        }

        // GET: Pupils/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pupils/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Rg,Cpf,Datanascimento,Genero,Contato,Email,Curso,Matricula")] Pupil pupil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pupil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pupil);
        }

        // GET: Pupils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pupil = await _context.Aluno.FindAsync(id);
            if (pupil == null)
            {
                return NotFound();
            }
            return View(pupil);
        }

        // POST: Pupils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Rg,Cpf,Datanascimento,Genero,Contato,Email,Curso,Matricula")] Pupil pupil)
        {
            if (id != pupil.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pupil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PupilExists(pupil.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pupil);
        }

        // GET: Pupils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pupil = await _context.Aluno
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pupil == null)
            {
                return NotFound();
            }

            return View(pupil);
        }

        // POST: Pupils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pupil = await _context.Aluno.FindAsync(id);
            _context.Aluno.Remove(pupil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PupilExists(int id)
        {
            return _context.Aluno.Any(e => e.Id == id);
        }
    }
}
