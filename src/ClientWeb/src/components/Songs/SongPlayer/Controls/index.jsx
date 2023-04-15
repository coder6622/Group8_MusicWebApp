import React from 'react';
import ProgressBar from './ProgressBar';
import PlayControl from './PlayControl';
import NextControl from './NextControl';
import PreviousControl from './PreviousControl';
import RepeatControl from './RepeatControl';
import ShuffleControl from './ShuffleControl';
import SongInfo from './SongInfo';
import VolumeControl from './VolumeControl';
import VolumeSliderControl from './VolumeSliderControl';
import LyricControl from './LyricControl';

function PlayerControl() {
  return (
    <div className='h-[--player-height] bg-black flex px-5 items-center gap-12'>
      <div className='basis-auto'>
        <SongInfo />
      </div>
      <div className='flex flex-col gap-2 items-center flex-1'>
        <div className='flex gap-4'>
          <RepeatControl />
          <PreviousControl />
          <PlayControl />
          <NextControl />
          <ShuffleControl />
        </div>
        <ProgressBar />
      </div>
      <div className='flex items-center basis-auto justify-end'>
        <LyricControl />
        <VolumeControl />
        <VolumeSliderControl />
      </div>
    </div>
  );
}

export default PlayerControl;
