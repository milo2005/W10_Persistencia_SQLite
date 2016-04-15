using EPersistencia.Models;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPersistencia.DataBase
{
    public class PlanetaDao
    {
        SQLiteConnection db;


        public PlanetaDao() {
            db = new SQLiteConnection("planetas.db");
            string sql = "CREATE IF NOT EXISTS planeta ("
                + "id INTEGER PRIMARY KEY AUTOINCREMENT"
                + ", nombre VARCHAR"
                + ", tamanio FLOAT"
                + ", gravedad FLOAT"
                + ")";

            using (var stm = db.Prepare(sql)) {
                stm.Step();
            }
        }

        public void insertPlaneta(Planeta p) {
            string sql = "INSERT INTO planeta (nombre, tamanio, gravedad)"
                + " VALUES (?,?,?)";

            using (var stm = db.Prepare(sql)) {
                stm.Bind(1, p.Nombre);
                stm.Bind(2, p.Tamanio);
                stm.Bind(3, p.Gravedad);
                stm.Step();
            }



        }

        public void updatePlaneta(Planeta p) {
            string sql = "UPDATE planeta SET nombre = ?, tamanio = ?, gravedad = ?"
                + " WHERE id = ?";
            using (var stm = db.Prepare(sql))
            {
                stm.Bind(1, p.Nombre);
                stm.Bind(2, p.Tamanio);
                stm.Bind(3, p.Gravedad);
                stm.Bind(4, p.Id);
                stm.Step();
            }

        }

        public void deletePlaneta(long id) {
            string sql = "DELETE FROM planeta WHERE id = ?";
            using (var stm = db.Prepare(sql))
            {
                stm.Bind(1, id);
                stm.Step();
            }

        }

        public Planeta getPlanetaById(long id) { 
            string sql = "SELECT * FROM planeta WHERE id = ?";
            using(SQLiteStatement stm = db.Prepare(sql) as SQLiteStatement){
                stm.Bind(1, id);
                if (stm.Step() == SQLiteResult.ROW) {
                    return stmToPlaneta(stm);
                }
            }

            return null;
        }

        public List<Planeta> getAllPlaneta() {
            string sql = "SELECT * FROM planeta";
            return stmToList(sql);
        }

        public List<Planeta> getPlanetaByNombre(string nombre) {
            string sql = "SELECT * FROM planeta WHERE nombre LIKE '%"+nombre+"%'";
            return stmToList(sql);
        }

        private List<Planeta> stmToList(string sql) {
            List<Planeta> data = new List<Planeta>();
            using (var stm = db.Prepare(sql) as SQLiteStatement)
            {
                while (stm.Step() == SQLiteResult.ROW)
                {
                    Planeta p = stmToPlaneta(stm);
                    data.Add(p);
                }
            }

            return data;
        }

        private Planeta stmToPlaneta(SQLiteStatement stm) {
            Planeta p = new Planeta();
            p.Id = (long)stm[0];
            p.Nombre = (string)stm[1];
            p.Tamanio = (float)stm[2];
            p.Gravedad = (float)stm[3];
            return p;
        }

    }
}
