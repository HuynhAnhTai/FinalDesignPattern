using QuanLyCosmestic.ui.templatePattern;

namespace QuanLyCosmestic.ui.strategyPatternMenu
{
    class MenuItemClickImp: MenuItemClick
    {
        private ControlScreen controlStreen;

        public MenuItemClickImp()
        {
        }

        public void clickScreen(ControlScreen control)
        {
            controlStreen = control;
            controlStreen.screenClick();
        }

        public void fristActive(ControlScreen control)
        {
            controlStreen = control;
            controlStreen.fristActive();
        }

    }
}
