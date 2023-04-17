import LyricIcon from 'components/icons/LyricIcon';
import { IconColor, IconSize } from 'constants/icon';
import React from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { setOpenLyric } from 'store/features/audioSlice';

export default function LyricControl() {
  const dispatch = useDispatch();

  const isShowLyric = useSelector((state) => state.audioPlayer.showLyric);

  const handleShowLyric = () => {
    isShowLyric ? dispatch(setOpenLyric(false)) : dispatch(setOpenLyric(true));
  };
  return (
    <button
      className='btn-controls'
      onClick={handleShowLyric}
    >
      <LyricIcon
        setColor={IconColor}
        setWidth={IconSize.small}
        setHeight={IconSize.small}
      />
    </button>
  );
}
