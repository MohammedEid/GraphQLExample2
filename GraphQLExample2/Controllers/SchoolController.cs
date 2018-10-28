using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GraphQL;
using GraphQL.Types;
using GraphQL.Language.AST;

namespace GraphQLExample2.Controllers
{
    [Route("api/school")] 
    public class SchoolController : ApiController
    {
        public readonly DocumentExecuter _documentExecuter;
        public readonly Schema _schema;
        public SchoolController()
        {
            //test commit 2
            //test clone
            //test clone 2
            _documentExecuter = new DocumentExecuter();
            _schema = new SchoolSchema();
            //_schema.RegisterTypes(new CourseType(), new StudentType());
            //_schema.RegisterValueConverter(new ByteValueConverter());
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<object> Post([FromBody]GraphQLQuery query)
        {
            if (query == null) { throw new ArgumentNullException(nameof(query)); }

            var executionOptions = new ExecutionOptions()
            {
                Schema = _schema,
                Query = query.Query,
                Inputs = query.Variables.ToInputs()
            };
            try
            {
                var result = await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);

                return Ok(result);
            }
            catch (Exception ex)
            {

            }

            return null;
        }
    }
}
