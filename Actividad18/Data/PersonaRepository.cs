using Microsoft.EntityFrameworkCore;

namespace Actividad18.Data
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly AppDbContext _context;

        public PersonaRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Persona>> GetAllAsync()
        {
            return await _context.Personas.ToListAsync();
        }

        public async Task<Persona?> GetByIdAsync(int id)
        {
            return await _context.Personas.FindAsync(id);
        }

        public async Task AddAsync(Persona persona)
        {
            if (persona == null)
                throw new ArgumentNullException(nameof(persona));

            await _context.Personas.AddAsync(persona);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Persona persona)
        {
            if (persona == null)
                throw new ArgumentNullException(nameof(persona));

            _context.Personas.Update(persona);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var persona = await GetByIdAsync(id);
            if (persona == null)
                throw new KeyNotFoundException($"Persona with ID {id} not found.");

            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();
        }
    }
}
