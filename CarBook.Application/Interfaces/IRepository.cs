using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Tasarım desenini kurmak için sınıfların imzasını taşıyan interface'in tanımlanması

namespace CarBook.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();  // Tüm tablo elemanlarını alır.
        Task<T> GetByIdAsync(int id);  // Sadece ilgili id'ye sahip değeri alır.
        Task CreateAsync(T entity);  // Tabloya bir veri ekler.
        Task UpdateAsync(T entity);  // Tablodaki veriyi günceller.
        Task RemoveAsync(T entity);  // Tablodaki bir veriyi siler.

    }
}
