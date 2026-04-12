using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Usuarios.Modelos;

namespace Usuarios.Pages
{
    // Clase que representa el modelo de la página Razor "Bestiario"
    public class BestiarioModel : PageModel
    {
        // Contexto de la base de datos (Entity Framework)
        private readonly DBContext _context;

        // Constructor: recibe el contexto de la BD por inyección de dependencias
        public BestiarioModel(DBContext context)
        {
            _context = context;
        }

        // Propiedad enlazada al formulario (BindProperty permite capturar datos del POST)
        [BindProperty]
        public Mob MobActual { get; set; } = new Mob();

        // Lista que almacenará todos los mobs para mostrarlos en la vista
        public List<Mob> ListaMobs { get; set; } = new List<Mob>();

        // Método GET: se ejecuta al cargar la página
        // Sirve para mostrar los registros y opcionalmente cargar uno para editar
        public async Task OnGetAsync(int? idEditar)
        {
            // Obtiene todos los mobs de la base de datos
            ListaMobs = await _context.Mobs.ToListAsync();

            // Si se recibe un ID para editar
            if (idEditar.HasValue)
            {
                // Busca el mob por ID y lo asigna a MobActual
                // Si no lo encuentra, crea uno nuevo vacío
                MobActual = await _context.Mobs.FindAsync(idEditar.Value) ?? new Mob();
            }
        }

        // Método POST: se ejecuta al enviar el formulario
        // Sirve tanto para insertar (alta) como para actualizar (cambio)
        public async Task<IActionResult> OnPostAsync()
        {
            // Si el ID es 0, significa que es un nuevo registro
            if (MobActual.Id == 0)
            {
                _context.Mobs.Add(MobActual); // Inserta un nuevo mob
            }
            else
            {
                _context.Mobs.Update(MobActual); // Actualiza un mob existente
            }

            // Guarda los cambios en la base de datos
            await _context.SaveChangesAsync();

            // Redirige a la misma página para recargar los datos
            return RedirectToPage();
        }

        // Método POST para eliminar (baja)
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            // Busca el mob por su ID
            var mobEliminar = await _context.Mobs.FindAsync(id);

            // Si existe, lo elimina
            if (mobEliminar != null)
            {
                _context.Mobs.Remove(mobEliminar);
                await _context.SaveChangesAsync();
            }

            // Redirige a la misma página para actualizar la lista
            return RedirectToPage();
        }
    }
}