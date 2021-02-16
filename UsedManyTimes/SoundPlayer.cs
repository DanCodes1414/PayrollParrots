using Android.Content;
using Android.Media;

namespace PayrollParrots.UsedManyTimes
{
    public class SoundPlayer
    {
        public void PlaySound_ButtonClick(Context context)
        {
            MediaPlayer _player = MediaPlayer.Create(context, Resource.Drawable.buttonclick);
            _player.Start();
        }
        public void PlaySound_DeleteEmployee(Context context)
        {
            MediaPlayer _player = MediaPlayer.Create(context, Resource.Drawable.delete_sound);
            _player.Start();
        }
        public void PlaySound_AlertWarning(Context context)
        {
            MediaPlayer _player = MediaPlayer.Create(context, Resource.Drawable.alert_sound);
            _player.Start();
        }
    }
}