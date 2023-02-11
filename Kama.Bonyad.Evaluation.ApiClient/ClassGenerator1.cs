using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kama.Bonyad.Evaluation.ApiClient.Interface;
using model = Kama.Bonyad.Evaluation.Core.Model;

namespace Kama.Bonyad.Evaluation.ApiClient
{
	abstract class Service
    {
    }

		 partial class DepartmentService: Service, IDepartmentService
		 {
			public DepartmentService(IEvaluationClient client)
			{
				_client = client;
			}
			readonly IEvaluationClient _client;

			            public virtual Task<AppCore.Result<IEnumerable<Kama.Organization.Core.Model.Department>>> List( Kama.Organization.Core.Model.DepartmentListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/department/List";
							return _client.SendAsync<IEnumerable<Kama.Organization.Core.Model.Department>>(true, url, routeParamValues, httpHeaders, model);
						}

            		 }
  
		 partial class PositionService: Service, IPositionService
		 {
			public PositionService(IEvaluationClient client)
			{
				_client = client;
			}
			readonly IEvaluationClient _client;

			            public virtual Task<AppCore.Result<Kama.Organization.Core.Model.Position>> Add( Kama.Organization.Core.Model.Position model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/position/Add";
							return _client.SendAsync<Kama.Organization.Core.Model.Position>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<Kama.Organization.Core.Model.Position>> Edit( Kama.Organization.Core.Model.Position model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/position/Edit";
							return _client.SendAsync<Kama.Organization.Core.Model.Position>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<IEnumerable<Kama.Bonyad.Evaluation.Core.Model.EvaluationPosition>>> List( Kama.Organization.Core.Model.PositionListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/position/List";
							return _client.SendAsync<IEnumerable<Kama.Bonyad.Evaluation.Core.Model.EvaluationPosition>>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> Delete( Guid id, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"id", id == null ? null : id.ToString()}};
			const string url = "api/v1/position/Delete/{id:guid}";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders);
						}

            		 }
  
		 partial class AttachmentService: Service, IAttachmentService
		 {
			public AttachmentService(IEvaluationClient client)
			{
				_client = client;
			}
			readonly IEvaluationClient _client;

			            public virtual Task<AppCore.Result<Kama.Bonyad.Evaluation.Core.Model.Attachment>> Add( Kama.Bonyad.Evaluation.Core.Model.Attachment model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Attachment/Add";
							return _client.SendAsync<Kama.Bonyad.Evaluation.Core.Model.Attachment>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<Kama.Bonyad.Evaluation.Core.Model.Attachment>> Edit( Kama.Bonyad.Evaluation.Core.Model.Attachment model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Attachment/Edit";
							return _client.SendAsync<Kama.Bonyad.Evaluation.Core.Model.Attachment>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> Delete( Kama.Bonyad.Evaluation.Core.Model.Attachment model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Attachment/Delete";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<Kama.Bonyad.Evaluation.Core.Model.Attachment>> Get( Kama.Bonyad.Evaluation.Core.Model.Attachment model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Attachment/Get";
							return _client.SendAsync<Kama.Bonyad.Evaluation.Core.Model.Attachment>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<IEnumerable<Kama.Bonyad.Evaluation.Core.Model.Attachment>>> List( Kama.Bonyad.Evaluation.Core.Model.AttachmentListVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Attachment/List";
							return _client.SendAsync<IEnumerable<Kama.Bonyad.Evaluation.Core.Model.Attachment>>(true, url, routeParamValues, httpHeaders, model);
						}

            		 }
  
		 partial class BrandService: Service, IBrandService
		 {
			public BrandService(IEvaluationClient client)
			{
				_client = client;
			}
			readonly IEvaluationClient _client;

			            public virtual Task<AppCore.Result<Kama.Bonyad.Evaluation.Core.Model.Brand>> Add( Kama.Bonyad.Evaluation.Core.Model.Brand model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Brand/Add";
							return _client.SendAsync<Kama.Bonyad.Evaluation.Core.Model.Brand>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<Kama.Bonyad.Evaluation.Core.Model.Brand>> Edit( Kama.Bonyad.Evaluation.Core.Model.Brand model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Brand/Edit";
							return _client.SendAsync<Kama.Bonyad.Evaluation.Core.Model.Brand>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> Delete( Kama.Bonyad.Evaluation.Core.Model.Brand model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Brand/Delete";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<Kama.Bonyad.Evaluation.Core.Model.Brand>> Get( Kama.Bonyad.Evaluation.Core.Model.Brand model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Brand/Get";
							return _client.SendAsync<Kama.Bonyad.Evaluation.Core.Model.Brand>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<IEnumerable<Kama.Bonyad.Evaluation.Core.Model.Brand>>> List( Kama.Bonyad.Evaluation.Core.Model.BrandVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Brand/List";
							return _client.SendAsync<IEnumerable<Kama.Bonyad.Evaluation.Core.Model.Brand>>(true, url, routeParamValues, httpHeaders, model);
						}

            		 }
  
		 partial class DepoService: Service, IDepoService
		 {
			public DepoService(IEvaluationClient client)
			{
				_client = client;
			}
			readonly IEvaluationClient _client;

			            public virtual Task<AppCore.Result<Kama.Bonyad.Evaluation.Core.Model.Depo>> EnterStorageAsync( Kama.Bonyad.Evaluation.Core.Model.Depo model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Depo/EnterStorageAsync";
							return _client.SendAsync<Kama.Bonyad.Evaluation.Core.Model.Depo>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> Delete( Kama.Bonyad.Evaluation.Core.Model.Depo model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Depo/Delete";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<Kama.Bonyad.Evaluation.Core.Model.Depo>> Get( Kama.Bonyad.Evaluation.Core.Model.Depo model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Depo/Get";
							return _client.SendAsync<Kama.Bonyad.Evaluation.Core.Model.Depo>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<IEnumerable<Kama.Bonyad.Evaluation.Core.Model.Depo>>> List( Kama.Bonyad.Evaluation.Core.Model.DepoVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Depo/List";
							return _client.SendAsync<IEnumerable<Kama.Bonyad.Evaluation.Core.Model.Depo>>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<IEnumerable<Kama.Bonyad.Evaluation.Core.Model.DepoIndex>>> DepoIndexList( Kama.Bonyad.Evaluation.Core.Model.DepoVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Depo/DepoIndexList";
							return _client.SendAsync<IEnumerable<Kama.Bonyad.Evaluation.Core.Model.DepoIndex>>(true, url, routeParamValues, httpHeaders, model);
						}

            		 }
  
		 partial class ClassificationService: Service, IClassificationService
		 {
			public ClassificationService(IEvaluationClient client)
			{
				_client = client;
			}
			readonly IEvaluationClient _client;

			            public virtual Task<AppCore.Result<Kama.Bonyad.Evaluation.Core.Model.Classification>> Add( Kama.Bonyad.Evaluation.Core.Model.Classification model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Classification/Add";
							return _client.SendAsync<Kama.Bonyad.Evaluation.Core.Model.Classification>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<Kama.Bonyad.Evaluation.Core.Model.Classification>> Edit( Kama.Bonyad.Evaluation.Core.Model.Classification model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Classification/Edit";
							return _client.SendAsync<Kama.Bonyad.Evaluation.Core.Model.Classification>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> Delete( Kama.Bonyad.Evaluation.Core.Model.Classification model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Classification/Delete";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<Kama.Bonyad.Evaluation.Core.Model.Classification>> Get( Kama.Bonyad.Evaluation.Core.Model.Classification model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Classification/Get";
							return _client.SendAsync<Kama.Bonyad.Evaluation.Core.Model.Classification>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<IEnumerable<Kama.Bonyad.Evaluation.Core.Model.Classification>>> List( Kama.Bonyad.Evaluation.Core.Model.ClassificationVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Classification/List";
							return _client.SendAsync<IEnumerable<Kama.Bonyad.Evaluation.Core.Model.Classification>>(true, url, routeParamValues, httpHeaders, model);
						}

            		 }
  
		 partial class ItemService: Service, IItemService
		 {
			public ItemService(IEvaluationClient client)
			{
				_client = client;
			}
			readonly IEvaluationClient _client;

			            public virtual Task<AppCore.Result<Kama.Bonyad.Evaluation.Core.Model.Item>> Add( Kama.Bonyad.Evaluation.Core.Model.Item model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Item/Add";
							return _client.SendAsync<Kama.Bonyad.Evaluation.Core.Model.Item>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<Kama.Bonyad.Evaluation.Core.Model.Item>> Edit( Kama.Bonyad.Evaluation.Core.Model.Item model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Item/Edit";
							return _client.SendAsync<Kama.Bonyad.Evaluation.Core.Model.Item>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> Delete( Kama.Bonyad.Evaluation.Core.Model.Item model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Item/Delete";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<Kama.Bonyad.Evaluation.Core.Model.Item>> Get( Kama.Bonyad.Evaluation.Core.Model.Item model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Item/Get";
							return _client.SendAsync<Kama.Bonyad.Evaluation.Core.Model.Item>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<IEnumerable<Kama.Bonyad.Evaluation.Core.Model.Item>>> List( Kama.Bonyad.Evaluation.Core.Model.ItemVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Item/List";
							return _client.SendAsync<IEnumerable<Kama.Bonyad.Evaluation.Core.Model.Item>>(true, url, routeParamValues, httpHeaders, model);
						}

            		 }
  
		 partial class InformationService: Service, IInformationService
		 {
			public InformationService(IEvaluationClient client)
			{
				_client = client;
			}
			readonly IEvaluationClient _client;

			            public virtual Task<AppCore.Result<Kama.Bonyad.Evaluation.Core.Model.Information>> Add( Kama.Bonyad.Evaluation.Core.Model.Information model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Information/Add";
							return _client.SendAsync<Kama.Bonyad.Evaluation.Core.Model.Information>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<IEnumerable<Kama.Bonyad.Evaluation.Core.Model.Information>>> List( Kama.Bonyad.Evaluation.Core.Model.InformationVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Information/List";
							return _client.SendAsync<IEnumerable<Kama.Bonyad.Evaluation.Core.Model.Information>>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<Kama.Bonyad.Evaluation.Core.Model.Information>> AddClassificationInformation( Kama.Bonyad.Evaluation.Core.Model.Information model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Information/AddClassificationInformation";
							return _client.SendAsync<Kama.Bonyad.Evaluation.Core.Model.Information>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<IEnumerable<Kama.Bonyad.Evaluation.Core.Model.Information>>> ListClassificationInformation( Kama.Bonyad.Evaluation.Core.Model.InformationVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Information/ListClassificationInformation";
							return _client.SendAsync<IEnumerable<Kama.Bonyad.Evaluation.Core.Model.Information>>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> DeleteClassificationInformation( Kama.Bonyad.Evaluation.Core.Model.Information model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Information/DeleteClassificationInformation";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders, model);
						}

            		 }
  
		 partial class StockService: Service, IStockService
		 {
			public StockService(IEvaluationClient client)
			{
				_client = client;
			}
			readonly IEvaluationClient _client;

			            public virtual Task<AppCore.Result<Kama.Bonyad.Evaluation.Core.Model.Stock>> Add( Kama.Bonyad.Evaluation.Core.Model.Stock model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Stock/Add";
							return _client.SendAsync<Kama.Bonyad.Evaluation.Core.Model.Stock>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> AddList( List<Kama.Bonyad.Evaluation.Core.Model.Stock> model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Stock/AddList";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<IEnumerable<Kama.Bonyad.Evaluation.Core.Model.Stock>>> Get( Kama.Bonyad.Evaluation.Core.Model.Stock model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Stock/Get";
							return _client.SendAsync<IEnumerable<Kama.Bonyad.Evaluation.Core.Model.Stock>>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<IEnumerable<Kama.Bonyad.Evaluation.Core.Model.Stock>>> List( Kama.Bonyad.Evaluation.Core.Model.StockVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Stock/List";
							return _client.SendAsync<IEnumerable<Kama.Bonyad.Evaluation.Core.Model.Stock>>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> ChangeState( Kama.Bonyad.Evaluation.Core.Model.StockChengState model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Stock/ChangeState";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> SaleInPerson( List<Kama.Bonyad.Evaluation.Core.Model.Stock> model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Stock/ChangeState";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders, model);
						}

            		 }
  
		 partial class TagService: Service, ITagService
		 {
			public TagService(IEvaluationClient client)
			{
				_client = client;
			}
			readonly IEvaluationClient _client;

			            public virtual Task<AppCore.Result<Kama.Bonyad.Evaluation.Core.Model.Tag>> Add( Kama.Bonyad.Evaluation.Core.Model.Tag model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Tag/Add";
							return _client.SendAsync<Kama.Bonyad.Evaluation.Core.Model.Tag>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> Delete( Kama.Bonyad.Evaluation.Core.Model.Tag model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Tag/Delete";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<IEnumerable<Kama.Bonyad.Evaluation.Core.Model.Tag>>> List( Kama.Bonyad.Evaluation.Core.Model.TagVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Tag/List";
							return _client.SendAsync<IEnumerable<Kama.Bonyad.Evaluation.Core.Model.Tag>>(true, url, routeParamValues, httpHeaders, model);
						}

            		 }
  
		 partial class ProductClassificationService: Service, IProductClassificationService
		 {
			public ProductClassificationService(IEvaluationClient client)
			{
				_client = client;
			}
			readonly IEvaluationClient _client;

			            public virtual Task<AppCore.Result<Kama.Bonyad.Evaluation.Core.Model.ProductClassification>> Add( Kama.Bonyad.Evaluation.Core.Model.ProductClassification model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/ProductClassification/Add";
							return _client.SendAsync<Kama.Bonyad.Evaluation.Core.Model.ProductClassification>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<Kama.Bonyad.Evaluation.Core.Model.ProductClassification>> Edit( Kama.Bonyad.Evaluation.Core.Model.ProductClassification model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/ProductClassification/Edit";
							return _client.SendAsync<Kama.Bonyad.Evaluation.Core.Model.ProductClassification>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> Delete( Kama.Bonyad.Evaluation.Core.Model.ProductClassification model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/ProductClassification/Delete";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<Kama.Bonyad.Evaluation.Core.Model.ProductClassification>> Get( Kama.Bonyad.Evaluation.Core.Model.ProductClassification model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/ProductClassification/Get";
							return _client.SendAsync<Kama.Bonyad.Evaluation.Core.Model.ProductClassification>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<IEnumerable<Kama.Bonyad.Evaluation.Core.Model.ProductClassification>>> List( Kama.Bonyad.Evaluation.Core.Model.ProductClassificationVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/ProductClassification/List";
							return _client.SendAsync<IEnumerable<Kama.Bonyad.Evaluation.Core.Model.ProductClassification>>(true, url, routeParamValues, httpHeaders, model);
						}

            		 }
  }