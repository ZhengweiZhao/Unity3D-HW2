@[TOC](3D Game Programming & Design：空间与运动)

# 空间与运动
##  1、简答题
简答并用程序验证【建议做】

### 游戏对象运动的本质是什么？
> 游戏对象运动的本质，是它随着页面刷新而产生的连续的运动，包括游戏对象的位置、旋转、角度、大小等。

### 请用三种方法以上方法，实现物体的抛物线运动。
（如，修改Transform属性，使用向量Vector3的方法…）
- 我们知道抛物线运动也就是平抛运动的速度运算公式如下：
>水平初速度V<sub>x</sub> = V<sub>0</sub>
竖直方向速度V<sub>y</sub> = gt
其中g是重力加速度

在Unity3D的三维坐标系中，我们以xoz坐标系为例，分别用修改Transform属性、使用向量Vector3的方法、   的方法来实现物体的抛物线运动。
#### 方法一：修改Transform属性
物体在水平方向上速度不变，竖直方向上的速度由于重力而加速。我们根据平抛运动速度变化的特点在每个时间区间内改变transform的position属性即可，代码如下：
```javascript
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float xspeed = 5;//水平方向初速度
    public float zspeed = 0;
    public float g = 10;//重力加速度
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.right * Time.deltaTime * xspeed;
        this.transform.position += Vector3.down * Time.deltaTime * zspeed;
        zspeed += g * Time.deltaTime;
    }
}
```
> Transform.right moves the GameObject in the red arrow’s axis (X).

#### 方法二：使用向量Vector3
创建Vector3向量myVector，把每次position的改变叠加到该向量上，从而改变竖直方向上的速度，代码如下：
```javascript
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vector : MonoBehaviour
{
    public float xspeed = 5;//水平方向初速度
    public float zspeed = 0;
    public float g = 10;//重力加速度
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 myVector = new Vector3(Time.deltaTime * xspeed, -Time.deltaTime * zspeed, 0);
        this.transform.position += myVector;
        zspeed += g * Time.deltaTime;
    }
}
```
>public Vector3(float x, float y, float z);
>//Creates a new vector with given x, y components and sets z to zero.

#### 方法三：使用transform.Translate方法
方法三和二很像，也需要先创建一个向量，唯一的区别是这里通过translate方法来计算每一时刻的速度的，代码如下：
```javascript
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trans : MonoBehaviour
{
    public float xspeed = 5;//水平方向初速度
    public float zspeed = 0;
    public float g = 10;//重力加速度
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 myVector = new Vector3(Time.deltaTime * xspeed, -Time.deltaTime * zspeed, 0);
        this.transform.Translate(myVector);
        zspeed += g * Time.deltaTime;
    }
}
```
###  写一个程序，实现一个完整的太阳系。
 其他星球围绕太阳的转速必须不一样，且不在一个法平面上。
 代码如下：
```javascript
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class solar : MonoBehaviour
{
	// Start is called before the first frame update
	public Transform sun;
	public Transform mars;
	public Transform jupiter;
	public Transform saturn;
	public Transform uranus;
	public Transform neptune;
	public Transform mercury;
	public Transform venus;
	public Transform earth;

	void Start()
	{
		//init
		sun.position = Vector3.zero;
		mercury.position = new Vector3(1, 0, 0);
		venus.position = new Vector3(-2, 0, 0);
		earth.position = new Vector3(3, 0, 0);
		mars.position = new Vector3(-6, 0, 0);
		jupiter.position = new Vector3(-7, 0, 0);
		saturn.position = new Vector3(9, 0, 0);
		uranus.position = new Vector3(12, 0, 0);
		neptune.position = new Vector3(-14, 0, 0);
	}
	// Update is called once per frame
	void Update()
	{
		mars.RotateAround(sun.position, new Vector3(0, 13, 5), 10 * Time.deltaTime);
		mars.Rotate(new Vector3(0, 12, 5) * 40 * Time.deltaTime);

		jupiter.RotateAround(sun.position, new Vector3(0, 8, 3), 8 * Time.deltaTime);
		jupiter.Rotate(new Vector3(0, 10, 3) * 30 * Time.deltaTime);

		saturn.RotateAround(sun.position, new Vector3(0, 2, 1), 6 * Time.deltaTime);
		saturn.Rotate(new Vector3(0, 3, 1) * 20 * Time.deltaTime);

		uranus.RotateAround(sun.position, new Vector3(0, 9, 1), 6 * Time.deltaTime);
		uranus.Rotate(new Vector3(0, 10, 1) * 20 * Time.deltaTime);

		neptune.RotateAround(sun.position, new Vector3(0, 7, 1), 5 * Time.deltaTime);
		neptune.Rotate(new Vector3(0, 8, 1) * 30 * Time.deltaTime);

		mercury.RotateAround(sun.position, new Vector3(0, 3, 1), 20 * Time.deltaTime);
		mercury.Rotate(new Vector3(0, 5, 1) * 5 * Time.deltaTime);

		venus.RotateAround(sun.position, new Vector3(0, 2, 1), 15 * Time.deltaTime);
		venus.Rotate(new Vector3(0, 2, 1) * Time.deltaTime);

		earth.RotateAround(sun.position, Vector3.up, 10 * Time.deltaTime);
		earth.Rotate(Vector3.up * 30 * Time.deltaTime);

	}
}
```
效果图如下：
![在这里插入图片描述](https://img-blog.csdnimg.cn/2019092102295544.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MDM3NzY5MQ==,size_16,color_FFFFFF,t_70)
##  2、编程实践
### 阅读以下游戏脚本
Priests and Devils

Priests and Devils is a puzzle game in which you will help the Priests and Devils to cross the river within the time limit. There are 3 priests and 3 devils at one side of the river. They all want to get to the other side of this river, but there is only one boat and this boat can only carry two persons each time. And there must be one person steering the boat from one side to the other side. In the flash game, you can click on them to move them and click the go button to move the boat to the other direction. If the priests are out numbered by the devils on either side of the river, they get killed and the game is over. You can try it in many > ways. Keep all priests alive! Good luck!
### 程序需要满足的要求及实现情况
- play the game ( http://www.flash-game.net/game/2535/priests-and-devils.html )
- 列出游戏中提及的事物（Objects）
>Characters： Priests牧师、Devils魔鬼
Environment： Boat船、River河流、Coast岸
- 用表格列出玩家动作表（规则表），注意，动作越少越好

---------------------------
动作     | 条件
-------- | -----
开船  |船上有人，船在左岸或者右岸
下船  |船上有人，船到左岸或者右岸
开始岸牧师上船  | 船在开始岸，船有空位，开始岸有牧师
结束岸牧师上船  | 船在结束岸，船有空位，结束岸有牧师
开始岸魔鬼上船  | 船在开始岸，船有空位，开始岸有魔鬼
结束岸魔鬼上船  | 船在结束岸，船有空位，结束岸有魔鬼
- 在 GenGameObjects 中创建 长方形、正方形、球 及其色彩代表游戏中的对象，将游戏中对象做成预制：
![在这里插入图片描述](https://img-blog.csdnimg.cn/20190921143031620.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MDM3NzY5MQ==,size_16,color_FFFFFF,t_70)
- 整个游戏仅主摄像机和一个 Empty 对象， 其他对象必须代码动态生成。
- 请使用课件架构图编程，不接受非 MVC 结构程序
在这里首先对MVC结构做一个解释说明：
 **MVC 结构**
 	>MVC全名是Model View Controller，是模型(model)－视图(view)－控制器(controller)的缩写，一种软件设计典范，用一种业务逻辑、数据、界面显示分离的方法组织代码，将业务逻辑聚集到一个部件里面，在改进和个性化定制界面及用户交互的同时，不需要重新编写业务逻辑。MVC被独特的发展起来用于映射传统的输入、处理和输出功能在一个逻辑的图形化用户界面的结构中。
 
 	**在本游戏中的运用**
 	本游戏中所涉及的objects，包括牧师与魔鬼以及其他的所有环境的game  objects都是model，它们分别通过不同的controller类控制。除了控制各个object的controller以外，还有控制整个场景的FirstController控制着这个场景中的所有对象。和一个控制着场景的创建、切换、销毁、游戏暂停、游戏退出的Controller类。
 	
 ### 基于MVC 结构的代码分析
 
 **Model & Controller部分**
这部分主要分为两个小的分支，用于控制移动和用于具体控制各个object。
Moveable是一个可以挂载在GameObject上的类，Controller通过setDestination()让GameObject移动起来。
> - moveable：用于控制角色和船的移动。
```javascript
public class Moveable: MonoBehaviour {
		
		readonly float move_speed = 20;
		// change frequently
		int moving_status;	// 0->not moving, 1->moving to middle, 2->moving to dest
		Vector3 dest;
		Vector3 middle;
        //更新移动状态
		void Update() {
			if (moving_status == 1) {
				transform.position = Vector3.MoveTowards (transform.position, middle, move_speed * Time.deltaTime);
				if (transform.position == middle) {
					moving_status = 2;
				}
			} else if (moving_status == 2) {
				transform.position = Vector3.MoveTowards (transform.position, dest, move_speed * Time.deltaTime);
				if (transform.position == dest) {
					moving_status = 0;
				}
			}
		}
        //确定终点coast
		public void setDestination(Vector3 _dest) {
			dest = _dest;
			middle = _dest;
			if (_dest.y == transform.position.y) {	// boat moving
				moving_status = 2;
			}
			else if (_dest.y < transform.position.y) {	// character from coast to boat
				middle.y = transform.position.y;
			} else {								// character from boat to coast
				middle.x = transform.position.x;
			}
			moving_status = 1;
		}

		public void reset() {
			moving_status = 0;
		}
	}
```
> - CoastController：用于控制与河岸有关的动作，比如角色上下岸，船的离开和停靠。

CoastController，BoatController和MyCharacterController都是类似的，这里我们就以CoastController为例。首先封装了船和河岸的GameObject，在构造函数中实例化了一个perfab，并对河岸的位置进行一些初始化的设置。此外还提供了一些方法的定义使得场景控制器能够调用它们。
```javascript
 public class CoastController {
		readonly GameObject coast;
		readonly Vector3 from_pos = new Vector3(9,1,0);
		readonly Vector3 to_pos = new Vector3(-9,1,0);
		readonly Vector3[] positions;
		readonly int to_or_from;	// to->-1, from->1

		// change frequently
		MyCharacterController[] passengerPlaner;

		public CoastController(string _to_or_from) {
			positions = new Vector3[] {new Vector3(6.5F,2.25F,0), new Vector3(7.5F,2.25F,0), new Vector3(8.5F,2.25F,0), 
				new Vector3(9.5F,2.25F,0), new Vector3(10.5F,2.25F,0), new Vector3(11.5F,2.25F,0)};

			passengerPlaner = new MyCharacterController[6];

			if (_to_or_from == "from") {
				coast = Object.Instantiate (Resources.Load ("Perfabs/Stone", typeof(GameObject)), from_pos, Quaternion.identity, null) as GameObject;
				coast.name = "from";
				to_or_from = 1;
			} else {
				coast = Object.Instantiate (Resources.Load ("Perfabs/Stone", typeof(GameObject)), to_pos, Quaternion.identity, null) as GameObject;
				coast.name = "to";
				to_or_from = -1;
			}
		}

		public int getEmptyIndex() {
			for (int i = 0; i < passengerPlaner.Length; i++) {
				if (passengerPlaner [i] == null) {
					return i;
				}
			}
			return -1;
		}

		public Vector3 getEmptyPosition() {
			Vector3 pos = positions [getEmptyIndex ()];
			pos.x *= to_or_from;
			return pos;
		}

		public void getOnCoast(MyCharacterController characterCtrl) {
			int index = getEmptyIndex ();
			passengerPlaner [index] = characterCtrl;
		}

		public MyCharacterController getOffCoast(string passenger_name) {	// 0->priest, 1->devil
			for (int i = 0; i < passengerPlaner.Length; i++) {
				if (passengerPlaner [i] != null && passengerPlaner [i].getName () == passenger_name) {
					MyCharacterController charactorCtrl = passengerPlaner [i];
					passengerPlaner [i] = null;
					return charactorCtrl;
				}
			}
			Debug.Log ("cant find passenger on coast: " + passenger_name);
			return null;
		}

		public int get_to_or_from() {
			return to_or_from;
		}

		public int[] getCharacterNum() {
			int[] count = {0, 0};
			for (int i = 0; i < passengerPlaner.Length; i++) {
				if (passengerPlaner [i] == null)
					continue;
				if (passengerPlaner [i].getType () == 0) {	// 0->priest, 1->devil
					count[0]++;
				} else {
					count[1]++;
				}
			}
			return count;
		}

		public void reset() {
			passengerPlaner = new MyCharacterController[6];
		}
	}
```
这些方法中比较难理解的是getEmptyPosition()方法，这是因为character牧师和魔鬼要站在boat上，所以这里需要提前留出空位，让游戏角色能够移动到合适的位置。
> - MyCharacterController：用于控制6个角色的动作，比如上船，上岸等。
> - BoatController：用于控制船的运动以及角色的上下船绑定。

因为实现原理和CoastController类似，就不再赘述了，代码见GitHub。

**控制器之间的逻辑关系** 
- Director控制器：它就像是整个游戏的“导演”，场景的加载、切换等，也可以控制游戏暂停、结束等等。它只有一个实例，之后的任何返回值和各个方法之间的通信都会返回到这个实例对象上。
```javascript
public class Director : System.Object {
		private static Director _instance;
		public SceneController currentSceneController { get; set; }

		public static Director getInstance() {
			if (_instance == null) {
				_instance = new Director ();
			}
			return _instance;
		}
	}
```
- SceneController接口：上面Director类中的public SceneController currentSceneController { get; set; }就是SceneController接口的实现。Director通过调用SceneController接口中的方法，来实现对场景的控制权。
```javascript
public interface SceneController {
		void loadResources ();
	}
```
而接口不能直接创建对象，因此它必须要有一个继承它的类，这个类就是FirstController。
- FirstController：FirstController实现了具体的对游戏整体场景的控制方法。
```javascript
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class FirstController : MonoBehaviour, SceneController, UserAction {

	readonly Vector3 water_pos = new Vector3(0,0.5F,0);


	UserGUI userGUI;

	public CoastController fromCoast;
	public CoastController toCoast;
	public BoatController boat;
	private MyCharacterController[] characters;

	void Awake() {
		Director director = Director.getInstance ();
		director.currentSceneController = this;
		userGUI = gameObject.AddComponent <UserGUI>() as UserGUI;
		characters = new MyCharacterController[6];
		loadResources ();
	}

	public void loadResources() {
		GameObject water = Instantiate (Resources.Load ("Perfabs/Water", typeof(GameObject)), water_pos, Quaternion.identity, null) as GameObject;
		water.name = "water";

		fromCoast = new CoastController ("from");
		toCoast = new CoastController ("to");
		boat = new BoatController ();

		loadCharacter ();
	}

	private void loadCharacter() {
		for (int i = 0; i < 3; i++) {
			MyCharacterController cha = new MyCharacterController ("priest");
			cha.setName("priest" + i);
			cha.setPosition (fromCoast.getEmptyPosition ());
			cha.getOnCoast (fromCoast);
			fromCoast.getOnCoast (cha);

			characters [i] = cha;
		}

		for (int i = 0; i < 3; i++) {
			MyCharacterController cha = new MyCharacterController ("devil");
			cha.setName("devil" + i);
			cha.setPosition (fromCoast.getEmptyPosition ());
			cha.getOnCoast (fromCoast);
			fromCoast.getOnCoast (cha);

			characters [i+3] = cha;
		}
	}


	public void moveBoat() {
		if (boat.isEmpty ())
			return;
		boat.Move ();
		userGUI.status = check_game_over ();
	}

	public void characterIsClicked(MyCharacterController characterCtrl) {
		if (characterCtrl.isOnBoat ()) {
			CoastController whichCoast;
			if (boat.get_to_or_from () == -1) { // to->-1; from->1
				whichCoast = toCoast;
			} else {
				whichCoast = fromCoast;
			}

			boat.GetOffBoat (characterCtrl.getName());
			characterCtrl.moveToPosition (whichCoast.getEmptyPosition ());
			characterCtrl.getOnCoast (whichCoast);
			whichCoast.getOnCoast (characterCtrl);

		} else {									// character on coast
			CoastController whichCoast = characterCtrl.getCoastController ();

			if (boat.getEmptyIndex () == -1) {		// boat is full
				return;
			}

			if (whichCoast.get_to_or_from () != boat.get_to_or_from ())	// boat is not on the side of character
				return;

			whichCoast.getOffCoast(characterCtrl.getName());
			characterCtrl.moveToPosition (boat.getEmptyPosition());
			characterCtrl.getOnBoat (boat);
			boat.GetOnBoat (characterCtrl);
		}
		userGUI.status = check_game_over ();
	}

	int check_game_over() {	// 0->not finish, 1->lose, 2->win
		int from_priest = 0;
		int from_devil = 0;
		int to_priest = 0;
		int to_devil = 0;

		int[] fromCount = fromCoast.getCharacterNum ();
		from_priest += fromCount[0];
		from_devil += fromCount[1];

		int[] toCount = toCoast.getCharacterNum ();
		to_priest += toCount[0];
		to_devil += toCount[1];

		if (to_priest + to_devil == 6)		// win
			return 2;

		int[] boatCount = boat.getCharacterNum ();
		if (boat.get_to_or_from () == -1) {	// boat at toCoast
			to_priest += boatCount[0];
			to_devil += boatCount[1];
		} else {	// boat at fromCoast
			from_priest += boatCount[0];
			from_devil += boatCount[1];
		}
		if (from_priest < from_devil && from_priest > 0) {		// lose
			return 1;
		}
		if (to_priest < to_devil && to_priest > 0) {
			return 1;
		}
		return 0;			// not finish
	}

	public void restart() {
		boat.reset ();
		fromCoast.reset ();
		toCoast.reset ();
		for (int i = 0; i < characters.Length; i++) {
			characters [i].reset ();
		}
	}
}
```


 **View部分**
 - UserGUI
这里主要是调用OnGUI来实现一些图形界面的显示效果，以及设置游戏的restart，开始暂停等功能。
```javascript
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class UserGUI : MonoBehaviour {
	private UserAction action;
	public int status = 0;
	GUIStyle style;
	GUIStyle buttonStyle;

	void Start() {
		action = Director.getInstance ().currentSceneController as UserAction;

		style = new GUIStyle();
		style.fontSize = 40;
		style.alignment = TextAnchor.MiddleCenter;

		buttonStyle = new GUIStyle("button");
		buttonStyle.fontSize = 30;
	}
	void OnGUI() {
		if (status == 1) {
			GUI.Label(new Rect(Screen.width/2-50, Screen.height/2-85, 100, 50), "Gameover!", style);
			if (GUI.Button(new Rect(Screen.width/2-70, Screen.height/2, 140, 70), "Restart", buttonStyle)) {
				status = 0;
				action.restart ();
			}
		} else if(status == 2) {
			GUI.Label(new Rect(Screen.width/2-50, Screen.height/2-85, 100, 50), "You win!", style);
			if (GUI.Button(new Rect(Screen.width/2-70, Screen.height/2, 140, 70), "Restart", buttonStyle)) {
				status = 0;
				action.restart ();
			}
		}
	}
}
```
- ClickGUI
用于反馈用户的点击，并调用SceneController进行响应的。
```javascript
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.Mygame;

public class ClickGUI : MonoBehaviour {
	UserAction action;
	MyCharacterController characterController;

	public void setController(MyCharacterController characterCtrl) {
		characterController = characterCtrl;
	}

	void Start() {
		action = Director.getInstance ().currentSceneController as UserAction;
	}

	void OnMouseDown() {
		if (gameObject.name == "boat") {
			action.moveBoat ();
		} else {
			action.characterIsClicked (characterController);
		}
	}
}

```
 ### 运行效果
  ![在这里插入图片描述](https://img-blog.csdnimg.cn/20190921162253426.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MDM3NzY5MQ==,size_16,color_FFFFFF,t_70)![在这里插入图片描述](https://img-blog.csdnimg.cn/20190921162203628.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3dlaXhpbl80MDM3NzY5MQ==,size_16,color_FFFFFF,t_70)

[视频链接-lose🔗](https://pan.baidu.com/s/1NlAdavSuqG_JRI8tuxd4CQ)
[视频链接-win🔗](https://pan.baidu.com/s/1cKLCyXNKGS3CTLd8NB0eog)

- 最后
感觉这次作业的编程游戏难度还是挺大的，所以代码和设计思路很大程度上都是参考的这篇博客做的，感谢师兄的分享！[参考文档](https://blog.csdn.net/hellowangld/article/details/79805000)

[我的Github代码传送门](https://github.com/ZhengweiZhao/gotest)

