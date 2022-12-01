
// App: Evaluation.Client
// Developer: Pouya Faridi
// Version: 1.0

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using model = Kama.Bonyad.Evaluation.Core.Model;

namespace Kama.Bonyad.Evaluation.ApiClient.Interface
{

	public interface IEvaluationClient : Library.ApiClient.IClient
	{
	}

	public interface IEvaluationHostInfo:Library.ApiClient.IHostInfo
	{
	}

	public interface IService
	{
	}

		 public interface IDepartmentService: IService
		 {
						 				Task<AppCore.Result<IEnumerable<Kama.Organization.Core.Model.Department>>> List(Kama.Organization.Core.Model.DepartmentListVM model, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface IPositionService: IService
		 {
						 				Task<AppCore.Result<Kama.Organization.Core.Model.Position>> Add(Kama.Organization.Core.Model.Position model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<Kama.Organization.Core.Model.Position>> Edit(Kama.Organization.Core.Model.Position model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.EvaluationPosition>>> List(Kama.Organization.Core.Model.PositionListVM model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Delete(Guid id, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface IAttachmentService: IService
		 {
						 				Task<AppCore.Result<model.Attachment>> Add(model.Attachment model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Attachment>> Edit(model.Attachment model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Delete(model.Attachment model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Attachment>> Get(model.Attachment model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.Attachment>>> List(model.AttachmentListVM model, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface IBrandService: IService
		 {
						 				Task<AppCore.Result<model.Brand>> Add(model.Brand model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Brand>> Edit(model.Brand model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Delete(model.Brand model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Brand>> Get(model.Brand model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.Brand>>> List(model.BrandVM model, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface IProductService: IService
		 {
						 				Task<AppCore.Result<model.Product>> Add(model.Product model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Product>> Edit(model.Product model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Delete(model.Product model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.Product>> Get(model.Product model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.Product>>> List(model.ProductVM model, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface IStockService: IService
		 {
						 				Task<AppCore.Result<model.Stock>> Add(model.Stock model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> AddList(List<model.Stock> model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.Stock>>> Get(model.Stock model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.Stock>>> List(model.StockVM model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> ChangeState(model.StockChengState model, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface ITagService: IService
		 {
						 				Task<AppCore.Result<model.Tag>> Add(model.Tag model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Delete(model.Tag model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.Tag>>> List(model.TagVM model, IDictionary<string, string> httpHeaders = null);

					 }

  		 public interface IProductClassificationService: IService
		 {
						 				Task<AppCore.Result<model.ProductClassification>> Add(model.ProductClassification model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.ProductClassification>> Edit(model.ProductClassification model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result> Delete(model.ProductClassification model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<model.ProductClassification>> Get(model.ProductClassification model, IDictionary<string, string> httpHeaders = null);

						 				Task<AppCore.Result<IEnumerable<model.ProductClassification>>> List(model.ProductClassificationVM model, IDictionary<string, string> httpHeaders = null);

					 }

  }