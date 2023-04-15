import React from 'react';

export default function VolumeSliderControl() {
  return (
    <input
      id='progress'
      className='w-36 h-1 bg-white rounded-sm cursor-pointer hover:h-2 hover:rounded-lg'
      // value='0'
      type='range'
      step='1'
      min='0'
      max='100'
    />
  );
}
