本文件下保存各页面的控件默认值。
文件格式如下：

<defaultValue>
  <item key="ListChfs" value="02"></item>
  <item key="ListZdch" value="N"></item>
  <item key="ListJjdd" text="是"></item>
  <item key="ListJjdd" index="0"></item>
</defaultValue>

其中，每一个item对应ViewModel的一个属性，key与属性同名，大小写也必须匹配。
value是控件的默认值。
需要注意的是： 如果控件是文本框，则value代表文本框的Text。
如果控件是下拉列表，value代表下拉项的Value（隐藏值，而不是显示文本）
当控件为下拉列表时，也可以不用value属性，而是用text属性，代表按照显示文本来指定默认值。
或者使用index属性，代表按照下拉项的顺序号来指定默认值。