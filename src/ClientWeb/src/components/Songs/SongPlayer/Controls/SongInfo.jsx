/* eslint-disable jsx-a11y/no-distracting-elements */
import { images } from 'assets';
import HearOutlineIcon from 'components/icons/HearOutlineIcon';
import MoreIcon from 'components/icons/MoreIcon';
import { IconColor, IconSize } from 'constants/icon';
import React from 'react';
import Marquee from 'react-fast-marquee';
import { useSelector } from 'react-redux';
import { Link } from 'react-router-dom';
import { isEmptyOrSpaces } from 'utils/Utils';

export default function SongInfo() {
  const isPlay = useSelector((state) => state.audioPlayer.isPlay);

  const songInfo = useSelector((state) => state.audioPlayer.infoSongPlayer);

  const imageUrl = isEmptyOrSpaces(songInfo.imageUrl)
    ? images.song_default
    : process.env.REACT_APP_PUBLIC_URL + songInfo.imageUrl;
  return (
    <div className='flex items-center gap-4'>
      <div
        className={`flex rounded-full w-16 h-16 object-cover border-2 border-white cursor-pointer bg-cover animate-slow-spin  ${
          isPlay ? '' : 'pause'
        } `}
        style={{
          backgroundImage: `url(${imageUrl})`,
        }}
      ></div>
      <div className='max-w-[180px] text-white list-none flex flex-col gap-1 justify-center cursor-default'>
        <Marquee
          className='text-base font-bold '
          play={true}
          gradient={false}
          speed={40}
        >
          {songInfo.name}
        </Marquee>
        <Link
          to={''}
          className='text-xs no-underline overflow-hidden hover:underline'
        >
          {songInfo.artistsName}
        </Link>
      </div>
      <div className='flex gap-4'>
        <button
          className='btn-controls'
          title=''
        >
          <HearOutlineIcon
            setColor={IconColor}
            setWidth={IconSize.small}
            setHeight={IconSize.small}
          />
        </button>
        <button
          className='btn-controls'
          title=''
        >
          <MoreIcon
            setColor={IconColor}
            setWidth={IconSize.small}
            setHeight={IconSize.small}
          />
        </button>
      </div>
    </div>
  );
}
