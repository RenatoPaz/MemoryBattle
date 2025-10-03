using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoryBattle.Details;

using System.Windows.Forms;

namespace MemoryBattle
{
    public partial class FormGame : Form
    {
        private readonly GameSettings _settings;

        public FormGame(GameSettings settings)
        {
            InitializeComponent();
            _settings = settings;

            Text = $"Memory Battle — {_settings.Rows}x{_settings.Columns}";
            // TODO: create your engine/grid here using _settings
            // _engine = new GameEngine(_settings, ThemeValues.Get(_settings.Logo));
        }
    }
}
