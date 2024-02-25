﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonInfographics.Presentation.ViewModels
{
    public class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel
            => App.ServiceProvider.GetRequiredService<MainWindowViewModel>();
    }
}
