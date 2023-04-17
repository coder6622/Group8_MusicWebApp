export const formatDuration = (duration) => {
  var sec_num = parseInt(duration, 10);
  var hours = Math.floor(sec_num / 3600);
  var minutes = Math.floor(sec_num / 60) % 60;
  var seconds = sec_num % 60;

  return [hours, minutes, seconds]
    .map((v) => (v < 10 ? '0' + v : v))
    .filter((v, i) => v !== '00' || i > 0)
    .join(':');
};

export const isEmptyOrSpaces = (str) => {
  return (
    str == null ||
    str === undefined ||
    str === '' ||
    (typeof src === 'string' &&
      (str.match(/^ *$/) !== null || str.length === 0))
  );
};
