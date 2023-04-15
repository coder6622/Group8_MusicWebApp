/* eslint-disable jsx-a11y/no-distracting-elements */
import HearOutlineIcon from 'components/icons/HearOutlineIcon';
import MoreIcon from 'components/icons/MoreIcon';
import { IconColor, IconSize } from 'constants/icon';
import React from 'react';
import { Link } from 'react-router-dom';

export default function SongInfo() {
  return (
    <div className='flex items-center gap-4'>
      <div
        className='flex rounded-full w-16 h-16 object-cover border-2 border-white cursor-pointer'
        style={{
          backgroundImage:
            'url(https://photo-resize-zmp3.zadn.vn/w240_r1x1_jpeg/cover/1/b/9/a/1b9a056a527b7c7409e890a48bb7fac6.jpg)',
        }}
      ></div>
      <div className='max-w-[200px] text-white list-none flex flex-col gap-1 justify-center cursor-none'>
        <marquee
          className='text-base overflow-hidden text-clip font-bold '
          scrolldelay='130'
        >
          Covid Nhanh Đi Đi
        </marquee>
        <Link
          to={''}
          className='text-xs no-underline overflow-hidden hover:underline'
        >
          K-ICM, APJ, Huyền Thanh Môn ...
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
