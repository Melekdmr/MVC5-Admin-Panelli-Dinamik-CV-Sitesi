using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Mvc_Dynamic_CV.Models.Entity;

namespace Mvc_Dynamic_CV.Repositories
{
	public class GenericRepository<T> where T : class, new()  // t türü için parametresiz bir yapıcı metoda sahip olmalıdır.
															  // Bu, GenericRepository sınıfı içinde new T() kullanılarak T
															  // türünden yeni bir nesne oluşturulabileceği anlamına gelir.
	{
		DbCvEntities db = new DbCvEntities();

		public List<T> List()
		{
			return db.Set<T>().ToList(); // T'den gelen değeri list olarak döndür.T değeri bütün tablolar olabilir
		}
		public void TAdd(T p)
		{
			db.Set<T>().Add(p);  //paremetreden gelen değeri T'ye ekle
			db.SaveChanges();
		}
		public void Tdelete(T p)
		{
			db.Set<T>().Remove(p);
			db.SaveChanges();
		}
		public T TGet(int id)
		{
			return db.Set<T>().Find(id);

		}
		public void TUpdate(T p)
		{
			db.SaveChanges();

		}
		public T Find(Expression<Func<T,bool>> where)  //Seçilen id ye eşit ilk değeri bul.Kayıt yoksa null döner.
													   //ilk kullanıcıyı bulur ve user değişkenine atar.
		{
			return db.Set<T>().FirstOrDefault(where);
		}
	}
}