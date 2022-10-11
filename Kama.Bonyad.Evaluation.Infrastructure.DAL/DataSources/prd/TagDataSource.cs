using Kama.AppCore;
using Kama.Bonyad.Evaluation.Core.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Kama.Bonyad.Evaluation.Infrastructure.DAL.DataSources
{
    class TagDataSource : DataSource, Core.DataSource.ITagDataSource
    {
        public TagDataSource(AppCore.IOC.IContainer container)
            : base(container)
        {
        }

        public async Task<Result<Tag>> AddAsync(Tag model)
        {
            try
            {
                var result = (await _dbPRD.AddTagAsync(
                    _productID: model.ProductID,
                    _tag: model.TagName
                    )).ToActionResult<Core.Model.Tag>();

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Result> DeleteAsync(Tag model)
        {
            try
            {
                var result = (await _dbPRD.DeleteTagAsync(
                    _productID: model.ProductID,
                    _tagID: model.TagID
                    )).ToActionResult(); 

                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Result<IEnumerable<Tag>>> ListAsync(TagVM model)
        {
            try
            {
                var result = (await _dbPRD.GetTagsAsync(
                    _productID:model.ProductID
                    )).ToListActionResult<Tag>();
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
