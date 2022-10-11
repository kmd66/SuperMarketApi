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
  
		 partial class ProductService: Service, IProductService
		 {
			public ProductService(IEvaluationClient client)
			{
				_client = client;
			}
			readonly IEvaluationClient _client;

			            public virtual Task<AppCore.Result<Kama.Bonyad.Evaluation.Core.Model.Product>> Add( Kama.Bonyad.Evaluation.Core.Model.Product model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Product/Add";
							return _client.SendAsync<Kama.Bonyad.Evaluation.Core.Model.Product>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<Kama.Bonyad.Evaluation.Core.Model.Product>> Edit( Kama.Bonyad.Evaluation.Core.Model.Product model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Product/Edit";
							return _client.SendAsync<Kama.Bonyad.Evaluation.Core.Model.Product>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result> Delete( Kama.Bonyad.Evaluation.Core.Model.Product model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Product/Delete";
							return _client.SendAsync(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<Kama.Bonyad.Evaluation.Core.Model.Product>> Get( Kama.Bonyad.Evaluation.Core.Model.Product model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Product/Get";
							return _client.SendAsync<Kama.Bonyad.Evaluation.Core.Model.Product>(true, url, routeParamValues, httpHeaders, model);
						}

                        public virtual Task<AppCore.Result<IEnumerable<Kama.Bonyad.Evaluation.Core.Model.Product>>> List( Kama.Bonyad.Evaluation.Core.Model.ProductVM model, IDictionary<string, string> httpHeaders = null)
			{
						var routeParamValues = new Dictionary<string, string>{{"model", model == null ? null : model.ToString()}};
			const string url = "api/v1/Product/List";
							return _client.SendAsync<IEnumerable<Kama.Bonyad.Evaluation.Core.Model.Product>>(true, url, routeParamValues, httpHeaders, model);
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