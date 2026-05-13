using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Usuarios.Modelos;

namespace Usuarios.Pages
{
    public class InventarioModel : PageModel
    {
        private readonly DBContext _context;

        public InventarioModel(DBContext context)
        {
            _context = context;
        }

        public List<Producto> ListaProductos { get; set; } = new List<Producto>();

        [BindProperty]
        public Producto ProductoActual { get; set; } = new Producto();

        public async Task OnGetAsync(int? idEditar)
        {
            ListaProductos = await _context.Productos.ToListAsync();

            if (idEditar.HasValue)
            {
                ProductoActual = await _context.Productos.FindAsync(idEditar.Value);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ProductoActual.Id == 0)
            {
                // ALTA
                _context.Productos.Add(ProductoActual);
            }
            else
            {
                // ACTUALIZACIÓN
                _context.Productos.Update(ProductoActual);
            }

            await _context.SaveChangesAsync();
            return RedirectToPage();
        }

        // BAJA
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var prodEliminar = await _context.Productos.FindAsync(id);
            if (prodEliminar != null)
            {
                _context.Productos.Remove(prodEliminar);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}