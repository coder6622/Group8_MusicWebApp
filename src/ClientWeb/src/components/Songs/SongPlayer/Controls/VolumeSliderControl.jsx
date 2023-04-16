import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { changeIconVolume, setVolume } from 'store/features/audioSlice';
import { isEmptyOrSpaces } from 'utils/Utils';

export default function VolumeSliderControl({ songRef }) {
  const dispatch = useDispatch();

  const volume = useSelector((state) => state.audioPlayer.volume) || 0;

  const handleChangVolume = (e) => {
    const value = Number(e.target.value);
    if (songRef) {
      localStorage.setItem('volume', value / 100);
      dispatch(setVolume(value / 100));
      songRef.volume = value / 100;
      if (value === 0) {
        dispatch(changeIconVolume(true));
      } else {
        dispatch(changeIconVolume(false));
      }
    }
  };
  return (
    <input
      id='progress'
      className='w-36 h-1 bg-white rounded-sm cursor-pointer hover:h-2 hover:rounded-lg'
      value={volume * 100 || 0}
      type='range'
      onInput={handleChangVolume}
      step='1'
      min='0'
      max='100'
    />
  );
}
