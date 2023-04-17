import MuteIcon from 'components/icons/MuteIcon';
import VolumeIcon from 'components/icons/VolumeIcon';
import { IconColor, IconSize } from 'constants/icon';
import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { changeIconVolume, setVolume } from 'store/features/audioSlice';

export default function VolumeControl(props) {
  const { songRef } = props;
  const dispatch = useDispatch();

  const isMute = useSelector((state) => state.audioPlayer.isMute);

  const handleMute = () => {
    if (isMute) {
      dispatch(changeIconVolume(false));
      dispatch(setVolume(Number(localStorage.getItem('volume'))));

      if (songRef) {
        songRef.volume = Number(localStorage.getItem('volume'));
      }
    } else {
      dispatch(changeIconVolume(true));
      dispatch(setVolume(0));
      if (songRef) {
        songRef.volume = 0;
      }
    }
  };

  return (
    <button
      className='btn-controls'
      onClick={handleMute}
    >
      {isMute ? (
        <MuteIcon
          setColor={IconColor}
          setHeight={IconSize.small}
          setWidth={IconSize.small}
        />
      ) : (
        <VolumeIcon
          setColor={IconColor}
          setHeight={IconSize.small}
          setWidth={IconSize.small}
        />
      )}
    </button>
  );
}
