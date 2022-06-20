using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using DAL;
using Models;

namespace BLL
{
    public class CompraBLL
    {
        private Contexto _contexto;
        public CompraBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Existe(int id)
        {
            bool existe = false;

            try
            {
                existe = _contexto.Compras.Any(c => c.CompraId == id );
            }
            catch (Exception)
            {
                throw;
            }
            return existe;
        }
        public bool Guardar(Compras compra)
        {
            if (!Existe(compra.CompraId))
                return Modificar(compra);
            else
                return Insertar(compra);

        }
        private bool Modificar(Compras compra)
        {
            bool paso = false;
            try
            {
                _contexto.Database.ExecuteSqlRaw($"DELETE FROM ComprasDetalle WHERE CompraId={compra.CompraId}");
                foreach (var Anterior in compra.Detalle)
                {
                    _contexto.Entry(Anterior).State = EntityState.Added;
                }
                _contexto.Entry(compra).State = EntityState.Modified;

                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                throw e;
            }
            return paso;
        }
        private bool Insertar(Compras compra)
        {
            bool paso = false;

            try
            {
                if (_contexto.Compras.Add(compra) != null)
                    paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }
        public Compras Buscar(int Id)
        {
            Compras compra;
            try
            {
                compra = _contexto.Compras.Include(x => x.Detalle).Where(c => c.CompraId == Id).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return compra;
        }

        public bool Eliminar(int id)
        {
            bool paso = false;

            try
            {
                var compra = _contexto.Compras.Find(id);
                if (compra != null)
                {
                    _contexto.Compras.Remove(compra);
                    paso = _contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

         public List<Compras> GetList(Expression<Func<Compras, bool>>criterio)
        {
            List<Compras> Lista = new List<Compras>();
            try
            {
                Lista = _contexto.Compras.Where(criterio).ToList();
            }catch(Exception)
            {
                throw;
            }
            return Lista;
        }
    }
}