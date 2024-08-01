using LojaRoupasApi.Domain.Dto;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace LojaRoupasApi.Domain.Binders
{
    public class ProdutoDtoBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(ProdutoDto))
            {
                return new ProdutoDtoBinder();
            }

            return null;
        }
    }
}