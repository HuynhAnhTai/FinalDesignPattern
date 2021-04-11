using QuanLyCosmestic.ui.templatePattern;

namespace QuanLyCosmestic.mediatorControlScreen
{
    interface CenterMediatorControlScreen
    {
        void notifyDataChange(TypeDataChange typeUpdate, ControlScreen controlNotify);
        void addControlScreen(ControlScreen cs);
    }
}
