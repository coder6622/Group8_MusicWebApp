import ArrowDownIcon from 'components/icons/ArrowDownIcon';
import { IconColor, IconSize } from 'constants/icon';
import React from 'react';
import { useEffect } from 'react';
import { useRef } from 'react';
import { Lrc } from 'react-lrc';
import { useDispatch, useSelector } from 'react-redux';
import { setOpenLyric } from 'store/features/audioSlice';

export default function Lyric(props) {
  const dispatch = useDispatch();

  const isShowLyric = useSelector((state) => state.audioPlayer.showLyric);

  const lyrics = useSelector((state) => state.audioPlayer.lyrics);

  const handleCloseLyric = () => {
    if (isShowLyric) {
      dispatch(setOpenLyric(false));
    } else {
      dispatch(setOpenLyric(true));
    }
  };

  return (
    <div
      className={`fixed bg-black transition-all ease-linear duration-300 z-10 ${
        isShowLyric
          ? 'animate-[lyric-up_1s] top-0 left-0 right-0 bottom-[var(--player-height)]'
          : 'animate-[lyric-down_1s] top-full bottom-0 left-0 right-0'
      }`}
    >
      <button
        className={`p-2 mx-3 my-3 rounded-[25%] transition-all duration-200 hover:bg-white hover:text-black text-white ${
          isShowLyric ? 'fixed top-6 right-6' : ''
        }`}
        title='Close'
        onClick={handleCloseLyric}
      >
        <ArrowDownIcon
          setColor={IconColor}
          setWidth={IconSize.lg}
          setHeight={IconSize.lg}
        />
      </button>

      <div className='font-semibold text-[28px] text-[color:var(--color-text)] max-w-2xl mx-auto my-0 h-full flex flex-col overflow-y-auto overflow-x-hidden'>
        <div className='mt-[50vh]'>
          <Lrc
            lrc={lyrics || ''}
            lineRenderer={({ index, line }) => `${index}. ${line.content}`}
          />
        </div>
      </div>
    </div>
  );
}
