
<Ribbon>
  <!--Header为开始的RibbonTab默认已经存在.
  当对已经存在的RibbonTab进行定义时,系统将判断Tag属性.
  当Tag为Append时,保留已存在的内容,并将这里定义的内容附加到原内容之后.
  当Tag为Overwrite时,这里定义的内容将覆盖原内容.
  如果未指定Tag属性,则默认Tag为Append-->
  <RibbonTab Header="开始" Tag="Overwrite/Append">
    <RibbonGroup Header="查询">
      <RibbonMenuButton LargeImageSource="Images/search.png" Label="查询">
        <RibbonMenuItem ImageSource="Images/search.png" Header="高级查询"></RibbonMenuItem>
      </RibbonMenuButton>
      <RibbonButton SmallImageSource="Images/first.png" Label="首页"></RibbonButton>
      <RibbonButton SmallImageSource="Images/prev.png" Label="上页" ></RibbonButton>
      <RibbonButton SmallImageSource="Images/export.png" Label="导出"></RibbonButton>
      <RibbonButton SmallImageSource="Images/last.png" Label="末页"></RibbonButton>
      <RibbonButton SmallImageSource="Images/next.png" Label="下页"></RibbonButton>
    </RibbonGroup>
  </RibbonTab>
  <!--当RibbonTab的Header不存在时,将创建新的RibbonTab.
  这时判断RibbonTab的IsSelected属性,当该属性为true时,立即切换到新创建的RibbonTab.
  当该属性缺省时,默认为true.
  如果同时创建了多个IsSelected为true的RibbonTab时,将激活最后一个RibbonTab.-->
  <RibbonTab Header="订单" IsSelected="True">
    <RibbonGroup Header="编辑">
      <RibbonMenuButton LargeImageSource="Images/save.png" Label="保存">
      </RibbonMenuButton>
      <RibbonButton SmallImageSource="Images/submit.png" Label="报送"></RibbonButton>
    </RibbonGroup>
    <RibbonGroup Header="审阅">
      <RibbonMenuButton LargeImageSource="Images/approve.png" Label="批准">
      </RibbonMenuButton>
      <RibbonButton SmallImageSource="Images/reject.png" Label="退回"></RibbonButton>
    </RibbonGroup>
  </RibbonTab>
</Ribbon>