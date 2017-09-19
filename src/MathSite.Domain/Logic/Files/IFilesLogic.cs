﻿using System;
using System.Threading.Tasks;
using MathSite.Entities;

namespace MathSite.Domain.Logic.Files
{
    public interface IFilesLogic
    {
        /// <summary>
        ///     Асинхронно создает файл.
        /// </summary>
        /// <param name="fileName">Название файла.</param>
        /// <param name="filePath">Путь к файлу.</param>
        /// <param name="extension">Расширение файла.</param>
        Task<Guid> CreateAsync(string fileName, string filePath, string extension);

        /// <summary>
        ///     Асинхронно обновляет файл.
        /// </summary>
        /// <param name="fileId">Идентификатор файла.</param>
        /// <param name="fileName">Название файла.</param>
        /// <param name="filePath">Путь к файлу.</param>
        /// <param name="extension">Расширение файла.</param>
        Task UpdateAsync(Guid fileId, string fileName, string filePath, string extension);

        /// <summary>
        ///     Асинхронно удаляет файл.
        /// </summary>
        /// <param name="fileId">Идентификатор файла.</param>
        Task DeleteAsync(Guid fileId);

        Task<File> TryGetByIdAsync(Guid id);
    }
}