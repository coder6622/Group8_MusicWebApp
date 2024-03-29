import React from 'react';

export default function ArrowDownIcon({
  setColor,
  setWidth,
  setHeight,
  ...orthers
}) {
  return (
    <svg
      width={setWidth}
      height={setHeight}
      viewBox='0 0 24 24'
      fill='none'
      xmlns='http://www.w3.org/2000/svg'
    >
      <path
        d='M12 17C11.2731 17 10.5463 16.7174 9.99596 16.1625L3.22584 9.33731C2.92472 9.03373 2.92472 8.53126 3.22584 8.22768C3.52697 7.92411 4.02538 7.92411 4.32651 8.22768L11.0966 15.0529C11.595 15.5554 12.405 15.5554 12.9034 15.0529L19.6735 8.22768C19.9746 7.92411 20.473 7.92411 20.7742 8.22768C21.0753 8.53126 21.0753 9.03373 20.7742 9.33731L14.004 16.1625C13.4537 16.7174 12.7269 17 12 17Z'
        fill={setColor}
      />
    </svg>
  );
}
