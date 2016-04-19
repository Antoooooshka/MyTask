using marmeladka.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using marmeladka.ViewModel;

namespace marmeladka.Validator
{
    public static class Validation
    {
        public static bool Validate(CategoryViewModel viewModel)
        {
            if (viewModel.Id is Guid)
                return true;
            else
                return false;
        }

        public static bool Validate(CompanyViewModel viewModel)
        {
            if (viewModel.Id is Guid)
                return true;
            else
                return false;
        }

        public static bool Validate(ProductViewModel viewModel)
        {
            if (viewModel.Id is Guid)
                return true;
            else
                return false;
        }

    }

}