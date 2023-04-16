import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { changeIconPlay } from 'store/features/audioSlice';
import { formatDuration } from 'utils/Utils';

function ProgressBar({ songRef }) {
  const dispatch = useDispatch();

  const { duration, currentTime } = useSelector((state) => state.audioPlayer);

  console.log((currentTime / duration) * 100);
  const handleChangeSeek = (e) => {
    const seek_time = (e.target.value / 100) * duration;
    songRef.currentTime = seek_time;
    songRef.play();
    dispatch(changeIconPlay(true));
  };

  return (
    <div className='w-full h-5 flex justify-around items-center gap-3'>
      <span className='text-sm cursor-default text-white'>
        {formatDuration(currentTime)}
      </span>
      <input
        id='progress'
        className='w-full h-1 bg-white rounded-sm cursor-pointer dark:bg-gray-700 overflow-hidden hover:h-2 hover:rounded-lg hover:overflow-visible'
        type='range'
        step='1'
        value={(currentTime / duration) * 100 || 0}
        onInput={handleChangeSeek}
        min='0'
        max='100'
      />
      <span className='text-sm cursor-default text-white'>
        {formatDuration(duration)}
      </span>
    </div>
  );
}

export default ProgressBar;
