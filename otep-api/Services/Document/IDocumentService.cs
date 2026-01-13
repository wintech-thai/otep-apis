using Its.Otep.Api.Models;
using Its.Otep.Api.ModelsViews;
using Its.Otep.Api.ViewsModels;

namespace Its.Otep.Api.Services
{
    public interface IDocumentService
    {
        public Task<MVDocument> GetDocumentById(string orgId, string documentId);
        public Task<MVDocument> AddDocument(string orgId, MDocument document);
        public Task<MVDocument> DeleteDocumentById(string orgId, string documentId);
        public Task<List<MDocument>> GetDocuments(string orgId, VMDocument param);
        public Task<int> GetDocumentCount(string orgId, VMDocument param);
        public Task<MVDocument> UpdateDocumentById(string orgId, string documentId, MDocument document);
    }
}
